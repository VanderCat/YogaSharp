using Yoga.Interop;

namespace Yoga; 

public partial class Node {
    public PositionType PositionType {
        get {
            unsafe {
                return (PositionType)YogaInterop.YGNodeStyleGetPositionType(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetPositionType(RawPointer, (YGPositionType)value);
            }
        }
    }

    public FlexDirection FlexDirection {
        get {
            unsafe {
                return (FlexDirection) YogaInterop.YGNodeStyleGetFlexDirection(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetFlexDirection(RawPointer, (YGFlexDirection)value);
            }
        }
    }

    public Align AlignItems {
        get {
            unsafe {
                return (Align)YogaInterop.YGNodeStyleGetAlignItems(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetAlignItems(RawPointer, (YGAlign)value);
            }
        }
    }
    
    public YogaValue StyleGetPosition(Edge edge) {
        unsafe {
            return YogaInterop.YGNodeStyleGetPosition(RawPointer, (YGEdge)edge).ToYogaValue();
        }
    }
    public void StyleSetPosition(Edge edge, float position) {
        unsafe {
            YogaInterop.YGNodeStyleSetPosition(RawPointer, (YGEdge)edge, position);
        }
    }
    public void StyleSetPositionPercent(Edge edge, float position) {
        unsafe {
            YogaInterop.YGNodeStyleSetPositionPercent(RawPointer, (YGEdge)edge, position);
        }
    }
    
    public YogaValue StyleGetMargin(Edge edge) {
        unsafe {
            return YogaInterop.YGNodeStyleGetMargin(RawPointer, (YGEdge)edge).ToYogaValue();
        }
    }
    public void StyleSetMargin(Edge edge, float margin) {
        unsafe {
            YogaInterop.YGNodeStyleSetMargin(RawPointer, (YGEdge)edge, margin);
        }
    }
    public void StyleSetMarginAuto(Edge edge) {
        unsafe {
            YogaInterop.YGNodeStyleSetMarginAuto(RawPointer, (YGEdge)edge);
        }
    }
    public void StyleSetMarginPercent(Edge edge, float margin) {
        unsafe {
            YogaInterop.YGNodeStyleSetMarginPercent(RawPointer, (YGEdge)edge, margin);
        }
    }
    public YogaValue StyleGetPadding(Edge edge) {
        unsafe {
            return YogaInterop.YGNodeStyleGetPadding(RawPointer, (YGEdge)edge).ToYogaValue();
        }
    }
    public void StyleSetPadding(Edge edge, float padding) {
        unsafe {
            YogaInterop.YGNodeStyleSetPadding(RawPointer, (YGEdge)edge, padding);
        }
    }
    public void StyleSetPaddingPercent(Edge edge, float padding) {
        unsafe {
            YogaInterop.YGNodeStyleSetPaddingPercent(RawPointer, (YGEdge)edge, padding);
        }
    }
    public float StyleGetBorder(Edge edge) {
        unsafe {
            return YogaInterop.YGNodeStyleGetBorder(RawPointer, (YGEdge)edge);
        }
    }
    public void StyleSetBorder(Edge edge, float border) {
        unsafe {
            YogaInterop.YGNodeStyleSetBorder(RawPointer, (YGEdge)edge, border);
        }
    }
    public void StyleSetWidthPercent(float percent) {
        unsafe {
            YogaInterop.YGNodeStyleSetWidthPercent(RawPointer, percent);
        }
    }
    public void StyleSetWidthAuto() {
        unsafe {
            YogaInterop.YGNodeStyleSetWidthAuto(RawPointer);
        }
    }
    public void StyleGetWidth() {
        unsafe {
            YogaInterop.YGNodeStyleGetWidth(RawPointer);
        }
    }
    public void StyleSetHeightPercent(float percent) {
        unsafe {
            YogaInterop.YGNodeStyleSetHeightPercent(RawPointer, percent);
        }
    }
    public void StyleSetHeightAuto() {
        unsafe {
            YogaInterop.YGNodeStyleSetHeightAuto(RawPointer);
        }
    }
    public void StyleGetHeight() {
        unsafe {
            YogaInterop.YGNodeStyleGetHeight(RawPointer);
        }
    }

    public void CopyStyleFrom(Node node) {
        unsafe {
            YogaInterop.YGNodeCopyStyle(RawPointer, node.RawPointer);
        }
    }

    public Direction StyleGetDirection() {
        unsafe {
            return (Direction)YogaInterop.YGNodeStyleGetDirection(RawPointer);
        }
    }

    public Justify JustifyContent {
        get {
            unsafe {
                return (Justify) YogaInterop.YGNodeStyleGetJustifyContent(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetJustifyContent(RawPointer, (YGJustify)value);
            }
        }
    }

    public Align AlignContent {
        get {
            unsafe {
                return (Align) YogaInterop.YGNodeStyleGetAlignContent(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetAlignContent(RawPointer, (YGAlign)value);
            }
        }
    }
    
    public Align AlignSelf {
        get {
            unsafe {
                return (Align) YogaInterop.YGNodeStyleGetAlignSelf(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetAlignSelf(RawPointer, (YGAlign)value);
            }
        }
    }
    
    public Wrap FlexWrap {
        get {
            unsafe {
                return (Wrap) YogaInterop.YGNodeStyleGetFlexWrap(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetFlexWrap(RawPointer, (YGWrap)value);
            }
        }
    }
    
    public Overflow Overflow {
        get {
            unsafe {
                return (Overflow) YogaInterop.YGNodeStyleGetOverflow(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetOverflow(RawPointer, (YGOverflow)value);
            }
        }
    }
    
    public Display Display {
        get {
            unsafe {
                return (Display) YogaInterop.YGNodeStyleGetDisplay(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetDisplay(RawPointer, (YGDisplay)value);
            }
        }
    }
    
    public float Flex {
        get {
            unsafe {
                return YogaInterop.YGNodeStyleGetFlex(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetFlex(RawPointer, value);
            }
        }
    }
    
    public float FlexGrow {
        get {
            unsafe {
                return YogaInterop.YGNodeStyleGetFlexGrow(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetFlexGrow(RawPointer, value);
            }
        }
    }
    
    public float FlexShrink {
        get {
            unsafe {
                return YogaInterop.YGNodeStyleGetFlexShrink(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetFlexShrink(RawPointer, value);
            }
        }
    }
    
    public Gutter StyleGetGap(Gutter gutter = Gutter.All) {
        unsafe {
            return (Gutter)YogaInterop.YGNodeStyleGetGap(RawPointer, (YGGutter)gutter);
        }
    }
    
    public void StyleSetGap(float gapLength, Gutter gutter = Gutter.All) {
        unsafe {
            YogaInterop.YGNodeStyleSetGap(RawPointer, (YGGutter)gutter, gapLength);
        }
    }

    public YogaValue StyleGetMinWidth() {
        unsafe {
            return YogaInterop.YGNodeStyleGetMinWidth(RawPointer).ToYogaValue();
        }
    }
    
    public void StyleSetMinHeight(float minHeight) {
        unsafe {
            YogaInterop.YGNodeStyleSetMinHeight(RawPointer, minHeight);
        }
    }
    
    public void StyleSetMinHeightPercent(float minHeightPercent) {
        unsafe {
            YogaInterop.YGNodeStyleSetMinWidthPercent(RawPointer, minHeightPercent);
        }
    }
    
    public YogaValue StyleGetMinHeight() {
        unsafe {
            return YogaInterop.YGNodeStyleGetMinHeight(RawPointer).ToYogaValue();
        }
    }
    
    public void StyleSetMinWidth(float minWidth) {
        unsafe {
            YogaInterop.YGNodeStyleSetMinWidth(RawPointer, minWidth);
        }
    }
    
    public void StyleSetMinWidthPercent(float minWidthPercent) {
        unsafe {
            YogaInterop.YGNodeStyleSetMinWidthPercent(RawPointer, minWidthPercent);
        }
    }
    
    public YogaValue StyleGetMaxWidth() {
        unsafe {
            return YogaInterop.YGNodeStyleGetMaxWidth(RawPointer).ToYogaValue();
        }
    }
    
    public void StyleSetMaxHeight(float minHeight) {
        unsafe {
            YogaInterop.YGNodeStyleSetMaxHeight(RawPointer, minHeight);
        }
    }
    
    public void StyleSetMaxHeightPercent(float minHeightPercent) {
        unsafe {
            YogaInterop.YGNodeStyleSetMaxWidthPercent(RawPointer, minHeightPercent);
        }
    }
    
    public YogaValue StyleGetMaxHeight() {
        unsafe {
            return YogaInterop.YGNodeStyleGetMaxHeight(RawPointer).ToYogaValue();
        }
    }
    
    public void StyleSetMaxWidth(float minWidth) {
        unsafe {
            YogaInterop.YGNodeStyleSetMaxWidth(RawPointer, minWidth);
        }
    }
    
    public void StyleSetMaxWidthPercent(float minWidthPercent) {
        unsafe {
            YogaInterop.YGNodeStyleSetMaxWidthPercent(RawPointer, minWidthPercent);
        }
    }

    public float AspectRatio {
        get {
            unsafe {
                return YogaInterop.YGNodeStyleGetAspectRatio(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetAspectRatio(RawPointer, value);
            }
        }
    }
}