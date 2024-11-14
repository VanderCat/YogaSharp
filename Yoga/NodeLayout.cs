using Yoga.Interop;

namespace Yoga; 

public partial class Node {
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

    public Direction Direction {
        get {
            unsafe {
                return (Direction)YogaInterop.YGNodeLayoutGetDirection(RawPointer);
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

    public float GetMargin(Edge edge) {
        unsafe {
            return YogaInterop.YGNodeLayoutGetMargin(RawPointer, (YGEdge) edge);
        }
    }
    
    public float GetBorder(Edge edge) {
        unsafe {
            return YogaInterop.YGNodeLayoutGetBorder(RawPointer, (YGEdge)edge);
        }
    }
    
    public float GetPadding(Edge edge) {
        unsafe {
            return YogaInterop.YGNodeLayoutGetPadding(RawPointer, (YGEdge)edge);
        }
    }
}