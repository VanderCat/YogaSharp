using Yoga.Interop;

namespace Yoga;

public class YogaNode : YogaBase {

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

    public float Width {
        get {
            unsafe {
                return YogaInterop.YGNodeLayoutGetWidth(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetWidth(RawPointer, value);
            }
        }
    }
    
    public float Height {
        get {
            unsafe {
                return YogaInterop.YGNodeLayoutGetHeight(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetHeight(RawPointer, value);
            }
        }
    }

    public float Left {
        get {
            unsafe {
                return YogaInterop.YGNodeLayoutGetLeft(RawPointer);
            }
        }
    }
    
    public float Top {
        get {
            unsafe {
                return YogaInterop.YGNodeLayoutGetTop(RawPointer);
            }
        }
    }
    
    public float Right {
        get {
            unsafe {
                return YogaInterop.YGNodeLayoutGetRight(RawPointer);
            }
        }
    }
    
    public float Bottom {
        get {
            unsafe {
                return YogaInterop.YGNodeLayoutGetBottom(RawPointer);
            }
        }
    }

    public YogaFlexDirection FlexDirection {
        get {
            unsafe {
                return (YogaFlexDirection) YogaInterop.YGNodeStyleGetFlexDirection(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetFlexDirection(RawPointer, (YGFlexDirection)value);
            }
        }
    }

    public YogaAlign AlignItems {
        get {
            unsafe {
                return (YogaAlign)YogaInterop.YGNodeStyleGetAlignItems(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetAlignItems(RawPointer, (YGAlign)value);
            }
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

    ~YogaNode() {
        unsafe {
            YogaInterop.YGNodeFinalize(RawPointer);
        }
    }

    public unsafe YogaNode(void* rawPointer) : base(rawPointer) { }

    public YogaNode() {
        unsafe {
            RawPointer = YogaInterop.YGNodeNew();
        }
    }
    
    public YogaNode(YogaConfig config) {
        unsafe {
            RawPointer = YogaInterop.YGNodeNewWithConfig(config.RawPointer);
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

    public void Print(YogaPrintOptions printOptions) {
        unsafe {
            YogaInterop.YGNodePrint(RawPointer, (YGPrintOptions)printOptions);
        }
    }

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