using System.Collections;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Yoga.Interop;

namespace Yoga;

public partial class YogaNode : YogaBase {
    private YogaConfig? _config;

    public YogaConfig? Config {
        get => _config;
        set {
            unsafe {
                _config = value;
                if (value is not null)
                    YogaInterop.YGNodeSetConfig(RawPointer, value.RawPointer);
            }
        }
    }
    
    public unsafe object? UserData {
        get => __USERDATA_CACHE.TryGetValue((nint)RawPointer, out var result) ? result : null;
        set => __USERDATA_CACHE[(nint)RawPointer] = value;
    }
    
    internal static Dictionary<nint, object?> __USERDATA_CACHE = new();

    private YogaNode? _owner;

    internal void SetParent(YogaNode? parent = null) {
        _owner = parent;
    }

    public YogaNode? Parent {
        get => _owner;
        set {
            if (value is not null)
                value.Children.Add(this);
            else
                _owner?.Children.Remove(this);
        }
    }

    public bool IsDirty {
        get {
            unsafe {
                return YogaInterop.YGNodeIsDirty(RawPointer);
            }
        }
        set {
            unsafe {
                if (value) YogaInterop.YGNodeMarkDirty(RawPointer);
            }
        }
    }

    public bool HasNewLayout {
        get {
            unsafe {
                return YogaInterop.YGNodeGetHasNewLayout(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeSetHasNewLayout(RawPointer, value);
            }
        }
    }

    public delegate void DirtiedFunction(YogaNode node);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate void DirtiedFunctionUnmanaged(void* node);

    public event DirtiedFunction? HaveDirtied;

    private unsafe DirtiedFunctionUnmanaged InvokeDirtiedEventGenerator() {

        return node => { HaveDirtied?.Invoke(this); };
    }

    public bool IsReferenceBaseline {
        get {
            unsafe {
                return YogaInterop.YGNodeIsReferenceBaseline(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeSetIsReferenceBaseline(RawPointer, value);
            }
        }
    }

    public YogaNodeList Children { get; }

    unsafe ~YogaNode() {
        __USERDATA_CACHE.Remove((nint) RawPointer);
        NodeFinalize(); //idk? what should i use here? finalizer? just straight up free?
    }

    private unsafe void AddDirtiedFunc() {
        var dirt = InvokeDirtiedEventGenerator();

#pragma warning disable CS8500
        YogaInterop.YGNodeSetDirtiedFunc(RawPointer,
            (delegate* unmanaged[Cdecl]<void*, void>) &dirt); //i hope this works (upd: IT DID NOT)
#pragma warning restore CS8500
    }

    public unsafe YogaNode(void* rawPointer) : base(rawPointer) {
        Children = new YogaNodeList(this);
        //AddDirtiedFunc();
    }

    public YogaNode() {
        unsafe {
            RawPointer = YogaInterop.YGNodeNew();
        }

        Children = new YogaNodeList(this);
        //AddDirtiedFunc();
    }

    public YogaNode(YogaConfig config) {
        unsafe {
            RawPointer = YogaInterop.YGNodeNewWithConfig(config.RawPointer);
        }

        Children = new YogaNodeList(this);
        //AddDirtiedFunc();
    }

    public YogaNode Clone() {
        unsafe {
            var cloned = new YogaNode(YogaInterop.YGNodeClone(RawPointer)) {
                _config = _config
            };
            return cloned;
        }
    }

#if DEBUG
    // YGNodePrint only exist in debug builds of yoga
    public void Print(YogaPrintOptions printOptions) {
        unsafe {
            YogaInterop.YGNodePrint(RawPointer, (YGPrintOptions) printOptions);
        }
    }
#endif

    public void Reset() {
        unsafe {
            YogaInterop.YGNodeReset(RawPointer);
        }
    }

    public void CalculateLayout(float width = Undefined, float height = Undefined,
        YogaDirection yogaDirection = YogaDirection.Inherit) {
        unsafe {
            YogaInterop.YGNodeCalculateLayout(RawPointer, width, height, (YGDirection) yogaDirection);
        }
    }

    internal void Free() {

        unsafe {
            YogaInterop.YGNodeFree(RawPointer);
        }
    }

    internal void FreeRecursive() {
        unsafe {
            foreach (var child in Children) {
                child.FreeRecursive();
            }

            Free();
            //YogaInterop.YGNodeFreeRecursive(RawPointer);
        }
    }

    internal void NodeFinalize() {
        unsafe {
            YogaInterop.YGNodeFinalize(RawPointer);
        }
    }

    private GCHandle? _contextHandle;

    [Obsolete(
        "I don't know why would you use that but if you know what you are doing i'm not stopping you (unlike me)")]
    public void SetUnmanagedContext<T>(T context) {
        _contextHandle?.Free();

        _contextHandle = GCHandle.Alloc(context, GCHandleType.Pinned);
        if (_contextHandle is not null)
            unsafe {
                YogaInterop.YGNodeSetContext(RawPointer, _contextHandle.Value.AddrOfPinnedObject().ToPointer());
                return;
            }
    }

    [Obsolete(
        "I don't know why would you use that but if you know what you are doing i'm not stopping you (unlike me)")]
    public T GetUnmanagedContext<T>() {
        unsafe {
            var ptr = YogaInterop.YGNodeGetContext(RawPointer);
            var method = new DynamicMethod("ConvertPtrToObjReference", typeof(T),
                new[] {typeof(void*)});
            var gen = method.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Ret);
            return (T) method.Invoke(null, BindingFlags.Default, null, new[] {(object) new IntPtr(ptr)}, null);
        }
    }

    public delegate Tuple<float, float> YogaMeasureFunction(YogaNode node, float width, YogaMeasureMode widthMode,
        float height, YogaMeasureMode heightMode);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate YGSize YGMeasureFunction(void* node, float width, YGMeasureMode widthMode, float height,
        YGMeasureMode heightMode);

    private YogaMeasureFunction? _measureFunction;

    public YogaMeasureFunction? MeasureFunction {
        get => _measureFunction;
        set {
            unsafe {
                _measureFunction = value;
                if (_measureFunction is null) {
                    YogaInterop.YGNodeSetMeasureFunc(RawPointer, null);
                    return;
                }

                YGMeasureFunction unmanaged = (node, width, mode, height, heightMode) => {
                    var result = _measureFunction.Invoke(this, width, (YogaMeasureMode) mode, height,
                        (YogaMeasureMode) heightMode);
                    return new YGSize() {
                        width = result.Item1,
                        height = result.Item2
                    };
                };

                YogaInterop.YGNodeSetMeasureFunc(RawPointer,
#pragma warning disable CS8500
                    (delegate*unmanaged[Cdecl]<void*, float, YGMeasureMode, float, YGMeasureMode, YGSize>) &unmanaged);
#pragma warning restore CS8500
            }
        }
    }

    public delegate float YogaBaselineFunction(YogaNode node, float width, float height);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate float YGBaselineFunc(void* node, float width, float height);

    private YogaBaselineFunction? _baselineFunction;

    public YogaBaselineFunction? BaselineFunction {
        get => _baselineFunction;
        set {
            unsafe {
                _baselineFunction = value;
                if (_baselineFunction is null) {
                    YogaInterop.YGNodeSetBaselineFunc(RawPointer, null);
                    return;
                }

                YGBaselineFunc unmanaged = (node, width, height) => _baselineFunction(this, width, height);

                YogaInterop.YGNodeSetBaselineFunc(RawPointer,
#pragma warning disable CS8500
                    (delegate*unmanaged[Cdecl]<void*, float, float, float>) &unmanaged);
#pragma warning restore CS8500
            }
        }
    }

    public YogaNodeType Type {
        get {
            unsafe {
                return (YogaNodeType)YogaInterop.YGNodeGetNodeType(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeSetNodeType(RawPointer, (YGNodeType)value);
            }
        }
    }

    public bool AlwaysFormsContainingBlock {
        set {
            unsafe {
                YogaInterop.YGNodeSetAlwaysFormsContainingBlock(RawPointer, value);
            }
        }
    }

}