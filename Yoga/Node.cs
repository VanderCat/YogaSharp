using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Yoga.Interop;

namespace Yoga;

public unsafe partial class Node : YGObject<Node>, IDisposable {
    
    private static Node GetOrCreate(nint ptr) {
        lock (__OBJECT_CACHE) {
            if (__OBJECT_CACHE.TryGetValue(ptr, out var weakRef)) {
                if (weakRef.TryGetTarget(out var existing))
                    return existing;
                __OBJECT_CACHE.Remove(ptr);
            }

            var obj = new Node();
            __OBJECT_CACHE[ptr] = new WeakReference<Node>(obj);
            return obj;
        }
    }
    
    public static implicit operator Node(void* o) => GetOrCreate((nint)o);
    public static implicit operator Node(nint o) => GetOrCreate(o);
    
    protected Node(void* pointer) : base(pointer) {
        Children = new NodeList(this);
    }

    public Node() {
        Pointer = YogaInterop.YGNodeNew();
        Children = new NodeList(this);
        __OBJECT_CACHE.Add(this, new WeakReference<Node>(this));
        SetDirtiedEvent();
    }

    public Node(YogaConfig config) {
        Pointer = YogaInterop.YGNodeNewWithConfig(config);

        Children = new NodeList(this);
        __OBJECT_CACHE.Add(this, new WeakReference<Node>(this));

        SetDirtiedEvent();
    }
    
    private bool _disposed;
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
 
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing) {
            __CONTEXT_CACHE.Remove(this);
        }
        Free();
        _disposed = true;
    }
    
    ~Node()
    {
        Dispose (false);
    }

    public void SetDirtiedEvent() {
        dirtiedFunctionUnmanaged = (void* node) => {
            HaveDirtied?.Invoke(this);
        };
        DirtiedFunc = dirtiedFunctionUnmanaged;
    }

    public DirtiedFunctionUnmanaged DirtiedFunc {
        get => Marshal.GetDelegateForFunctionPointer<DirtiedFunctionUnmanaged>((IntPtr)YogaInterop.YGNodeGetDirtiedFunc(this));
        set => YogaInterop.YGNodeSetDirtiedFunc(this, (delegate* unmanaged[Cdecl]<void*, void>)Marshal.GetFunctionPointerForDelegate(value));
    }
    
    private YogaConfig? _config;

    public YogaConfig? Config {
        get => _config;
        set {
            _config = value;
            //FIXME: if we null config what should we do?
            if (value is not null)
                YogaInterop.YGNodeSetConfig(this, value);
        }
    }

    private Node? _owner;

    internal void SetParent(Node? parent = null) {
        _owner = parent;
    }

    public Node? Parent {
        get => _owner;
        set {
            if (value is not null)
                value.Children.Add(this);
            else
                _owner?.Children.Remove(this);
        }
    }

    public bool IsDirty {
        get => YogaInterop.YGNodeIsDirty(this);
        set {
                if (value) YogaInterop.YGNodeMarkDirty(this);
        }
    }

    public bool HasNewLayout {
        get => YogaInterop.YGNodeGetHasNewLayout(this);
        set => YogaInterop.YGNodeSetHasNewLayout(this, value);
    }

    public delegate void DirtiedFunction(Node node);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void DirtiedFunctionUnmanaged(void* node);
    
    public event DirtiedFunction? HaveDirtied;

    private DirtiedFunctionUnmanaged dirtiedFunctionUnmanaged;

    public bool IsReferenceBaseline {
        get => YogaInterop.YGNodeIsReferenceBaseline(this);
        set => YogaInterop.YGNodeSetIsReferenceBaseline(this, value);
    }

    public NodeList Children { get; }

    public Node Clone() {
        var cloned = new Node(YogaInterop.YGNodeClone(this)) {
            _config = _config
        };
        return cloned;
    }

#if DEBUG
    // YGNodePrint only exist in debug builds of yoga
    public void Print(PrintOptions printOptions) {
        YogaInterop.YGNodePrint(this, (YGPrintOptions) printOptions);
    }
#endif

    public void Reset() {
        YogaInterop.YGNodeReset(this);
    }

    public void CalculateLayout(float width = Undefined, float height = Undefined,
        Direction direction = Direction.Inherit) {
        YogaInterop.YGNodeCalculateLayout(this, width, height, (YGDirection) direction);
    }

    internal void Free() {
        YogaInterop.YGNodeFree(this);
    }

    internal void FreeRecursive() {
        foreach (var child in Children) {
            child.FreeRecursive();
        }

        Free();
        //YogaInterop.YGNodeFreeRecursive(RawPointer);
    }

    internal void NodeFinalize() {
        YogaInterop.YGNodeFinalize(this);
    }

    public delegate SizeF MeasureFunc(Node node, float width, MeasureMode widthMode,
        float height, MeasureMode heightMode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate YGSize MeasureFuncUnmanaged(void* node, float width, YGMeasureMode widthMode, float height,
        YGMeasureMode heightMode);

    private MeasureFuncUnmanaged _measureFuncUnmanaged;

    private MeasureFunc? _measureFunction;

    public MeasureFunc? MeasureFunction {
        get => _measureFunction;
        set {
            _measureFunction = value;
            if (_measureFunction is null) {
                YogaInterop.YGNodeSetMeasureFunc(this, null);
                return;
            }

            _measureFuncUnmanaged = (node, width, mode, height, heightMode) => {
                var result = _measureFunction.Invoke(this, width, (MeasureMode) mode, height,
                    (MeasureMode) heightMode);
                return new() {
                    width = result.Width,
                    height = result.Height
                };
            };

            YogaInterop.YGNodeSetMeasureFunc(this,
                (delegate*unmanaged[Cdecl]<void*, float, YGMeasureMode, float, YGMeasureMode, YGSize>)
                Marshal.GetFunctionPointerForDelegate(_measureFuncUnmanaged));
        }
    }

    public delegate float BaselineFunc(Node node, float width, float height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate float BaselineFuncUnmanaged(void* node, float width, float height);

    private BaselineFuncUnmanaged? _baselineFunctionUnmanaged;
    
    private BaselineFunc? _baselineFunction;

    public BaselineFunc? BaselineFunction {
        get => _baselineFunction;
        set {
            _baselineFunction = value;
            if (_baselineFunction is null) {
                YogaInterop.YGNodeSetBaselineFunc(this, null);
                return;
            }

            _baselineFunctionUnmanaged = (node, width, height) => _baselineFunction(this, width, height);

            YogaInterop.YGNodeSetBaselineFunc(this,
                (delegate*unmanaged[Cdecl]<void*, float, float, float>) Marshal.GetFunctionPointerForDelegate(_baselineFunctionUnmanaged));
        }
    }

    public NodeType Type {
        get {
            return (NodeType)YogaInterop.YGNodeGetNodeType(this);
        }
        set {
            YogaInterop.YGNodeSetNodeType(this, (YGNodeType)value);
        }
    }

    public bool AlwaysFormsContainingBlock {
        set {
            YogaInterop.YGNodeSetAlwaysFormsContainingBlock(this, value);
        }
    }

}