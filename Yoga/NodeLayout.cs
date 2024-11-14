using Yoga.Interop;

namespace Yoga; 

public unsafe partial class Node {
    public float Width {
        get => YogaInterop.YGNodeLayoutGetWidth(this);
        set => YogaInterop.YGNodeStyleSetWidth(this, value);
    }
    
    public float Height {
        get => YogaInterop.YGNodeLayoutGetHeight(this);
        set => YogaInterop.YGNodeStyleSetHeight(this, value);
    }
    
    public float Left => YogaInterop.YGNodeLayoutGetLeft(this);

    public float Top => YogaInterop.YGNodeLayoutGetTop(this);

    public float Right => YogaInterop.YGNodeLayoutGetRight(this);

    public float Bottom => YogaInterop.YGNodeLayoutGetBottom(this);

    public Direction Direction {
        get => (Direction)YogaInterop.YGNodeLayoutGetDirection(this);
        set => YogaInterop.YGNodeStyleSetDirection(this, (YGDirection)value);
    }
    
    public bool HadOverflow => YogaInterop.YGNodeLayoutGetHadOverflow(this);

    public float GetMargin(Edge edge) {
        return YogaInterop.YGNodeLayoutGetMargin(this, (YGEdge) edge);
    }
    
    public float GetBorder(Edge edge) {
        return YogaInterop.YGNodeLayoutGetBorder(this, (YGEdge)edge);
    }
    
    public float GetPadding(Edge edge) {
        return YogaInterop.YGNodeLayoutGetPadding(this, (YGEdge)edge);
    }
}