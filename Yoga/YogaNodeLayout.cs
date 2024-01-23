using Yoga.Interop;

namespace Yoga; 

public partial class YogaNode {
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

    public YogaDirection Direction {
        get {
            unsafe {
                return (YogaDirection)YogaInterop.YGNodeLayoutGetDirection(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetDirection(RawPointer, (YGDirection)value);
            }
        }
    }
    
    public bool HadOverflow {
        get {
            unsafe {
                return YogaInterop.YGNodeLayoutGetHadOverflow(RawPointer);
            }
        }
    }

    public float GetMargin(YogaEdge edge) {
        unsafe {
            return YogaInterop.YGNodeLayoutGetMargin(RawPointer, (YGEdge) edge);
        }
    }
    
    public float GetBorder(YogaEdge edge) {
        unsafe {
            return YogaInterop.YGNodeLayoutGetBorder(RawPointer, (YGEdge)edge);
        }
    }
    
    public float GetPadding(YogaEdge edge) {
        unsafe {
            return YogaInterop.YGNodeLayoutGetPadding(RawPointer, (YGEdge)edge);
        }
    }
}