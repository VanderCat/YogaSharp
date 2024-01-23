using System.Collections;
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

    internal YogaNode _owner;
    public YogaNode Owner {
        get => _owner;
        set => value.Children.Add(this);
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

    public YogaNodeList Children;

    ~YogaNode() {
        unsafe {
            YogaInterop.YGNodeFinalize(RawPointer);
        }
    }

    public unsafe YogaNode(void* rawPointer) : base(rawPointer) {
        Children = new YogaNodeList(this);
    }

    public YogaNode() {
        unsafe {
            RawPointer = YogaInterop.YGNodeNew();
            Children = new YogaNodeList(this);
        }
    }
    
    public YogaNode(YogaConfig config) {
        unsafe {
            RawPointer = YogaInterop.YGNodeNewWithConfig(config.RawPointer);
            Children = new YogaNodeList(this);
        }
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
            YogaInterop.YGNodePrint(RawPointer, (YGPrintOptions)printOptions);
        }
    }
#endif

    public void Reset() {
        unsafe {
            YogaInterop.YGNodeReset(RawPointer);
        }
    }

    public void CalculateLayout(float width = Undefined, float height = Undefined, YogaDirection yogaDirection = YogaDirection.Inherit) {
        unsafe {
            YogaInterop.YGNodeCalculateLayout(RawPointer, width, height, (YGDirection)yogaDirection);
        }
    }
}