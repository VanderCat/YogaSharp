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
}