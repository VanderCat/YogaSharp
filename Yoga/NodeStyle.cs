using Yoga.Interop;

namespace Yoga; 

public unsafe partial class Node {
    public PositionType PositionType {
        get => (PositionType)YogaInterop.YGNodeStyleGetPositionType(this);
        set => YogaInterop.YGNodeStyleSetPositionType(this, (YGPositionType)value);
    }

    public FlexDirection FlexDirection {
        get => (FlexDirection) YogaInterop.YGNodeStyleGetFlexDirection(this);
        set => YogaInterop.YGNodeStyleSetFlexDirection(this, (YGFlexDirection)value);
    }

    public Align AlignItems {
        get => (Align)YogaInterop.YGNodeStyleGetAlignItems(this);
        set => YogaInterop.YGNodeStyleSetAlignItems(this, (YGAlign)value);
    }
    
    public YogaValue StyleGetPosition(Edge edge) {
        return YogaInterop.YGNodeStyleGetPosition(this, (YGEdge)edge).ToYogaValue();
    }
    public void StyleSetPosition(Edge edge, float position) {
        YogaInterop.YGNodeStyleSetPosition(this, (YGEdge)edge, position);
    }
    public void StyleSetPositionPercent(Edge edge, float position) {
        YogaInterop.YGNodeStyleSetPositionPercent(this, (YGEdge)edge, position);
    }
    
    public YogaValue StyleGetMargin(Edge edge) {
        return YogaInterop.YGNodeStyleGetMargin(this, (YGEdge)edge).ToYogaValue();
    }
    public void StyleSetMargin(Edge edge, float margin) {
        YogaInterop.YGNodeStyleSetMargin(this, (YGEdge)edge, margin);
    }
    public void StyleSetMarginAuto(Edge edge) {
        YogaInterop.YGNodeStyleSetMarginAuto(this, (YGEdge)edge);
    }
    public void StyleSetMarginPercent(Edge edge, float margin) {
        YogaInterop.YGNodeStyleSetMarginPercent(this, (YGEdge)edge, margin);
    }
    public YogaValue StyleGetPadding(Edge edge) {
        return YogaInterop.YGNodeStyleGetPadding(this, (YGEdge)edge).ToYogaValue();
    }
    public void StyleSetPadding(Edge edge, float padding) {
        YogaInterop.YGNodeStyleSetPadding(this, (YGEdge)edge, padding);
    }
    public void StyleSetPaddingPercent(Edge edge, float padding) {
        YogaInterop.YGNodeStyleSetPaddingPercent(this, (YGEdge)edge, padding);
    }
    public float StyleGetBorder(Edge edge) {
        return YogaInterop.YGNodeStyleGetBorder(this, (YGEdge)edge);
    }
    public void StyleSetBorder(Edge edge, float border) {
        YogaInterop.YGNodeStyleSetBorder(this, (YGEdge)edge, border);
    }
    public void StyleSetWidthPercent(float percent) {
        YogaInterop.YGNodeStyleSetWidthPercent(this, percent);
    }
    public void StyleSetWidthAuto() {
        YogaInterop.YGNodeStyleSetWidthAuto(this);
    }
    public void StyleGetWidth() {
        YogaInterop.YGNodeStyleGetWidth(this);
    }
    public void StyleSetHeightPercent(float percent) {
        YogaInterop.YGNodeStyleSetHeightPercent(this, percent);
    }
    public void StyleSetHeightAuto() {
        YogaInterop.YGNodeStyleSetHeightAuto(this);
    }
    public void StyleGetHeight() {
        YogaInterop.YGNodeStyleGetHeight(this);
    }

    public void CopyStyleFrom(Node node) {
        YogaInterop.YGNodeCopyStyle(this, node);
    }

    public Direction StyleGetDirection() {
        return (Direction)YogaInterop.YGNodeStyleGetDirection(this);
    }

    public Justify JustifyContent {
        get => (Justify) YogaInterop.YGNodeStyleGetJustifyContent(this);
        set => YogaInterop.YGNodeStyleSetJustifyContent(this, (YGJustify)value);
    }

    public Align AlignContent {
        get => (Align) YogaInterop.YGNodeStyleGetAlignContent(this);
        set => YogaInterop.YGNodeStyleSetAlignContent(this, (YGAlign)value);
    }
    
    public Align AlignSelf {
        get => (Align) YogaInterop.YGNodeStyleGetAlignSelf(this);
        set => YogaInterop.YGNodeStyleSetAlignSelf(this, (YGAlign)value);
    }
    
    public Wrap FlexWrap {
        get => (Wrap) YogaInterop.YGNodeStyleGetFlexWrap(this);
        set => YogaInterop.YGNodeStyleSetFlexWrap(this, (YGWrap)value);
    }
    
    public Overflow Overflow {
        get => (Overflow) YogaInterop.YGNodeStyleGetOverflow(this);
        set => YogaInterop.YGNodeStyleSetOverflow(this, (YGOverflow)value);
    }
    
    public Display Display {
        get => (Display) YogaInterop.YGNodeStyleGetDisplay(this);
        set => YogaInterop.YGNodeStyleSetDisplay(this, (YGDisplay)value);
    }
    
    public float Flex {
        get => YogaInterop.YGNodeStyleGetFlex(this);
        set => YogaInterop.YGNodeStyleSetFlex(this, value);
    }
    
    public float FlexGrow {
        get => YogaInterop.YGNodeStyleGetFlexGrow(this);
        set => YogaInterop.YGNodeStyleSetFlexGrow(this, value);
    }
    
    public float FlexShrink {
        get => YogaInterop.YGNodeStyleGetFlexShrink(this);
        set => YogaInterop.YGNodeStyleSetFlexShrink(this, value);
    }
    
    public Gutter StyleGetGap(Gutter gutter = Gutter.All) {
        return (Gutter)YogaInterop.YGNodeStyleGetGap(this, (YGGutter)gutter);
    }
    
    public void StyleSetGap(float gapLength, Gutter gutter = Gutter.All) {
        YogaInterop.YGNodeStyleSetGap(this, (YGGutter)gutter, gapLength);
    }

    public YogaValue StyleGetMinWidth() {
        return YogaInterop.YGNodeStyleGetMinWidth(this).ToYogaValue();
    }
    
    public void StyleSetMinHeight(float minHeight) {
        YogaInterop.YGNodeStyleSetMinHeight(this, minHeight);
    }
    
    public void StyleSetMinHeightPercent(float minHeightPercent) {
        YogaInterop.YGNodeStyleSetMinWidthPercent(this, minHeightPercent);
    }
    
    public YogaValue StyleGetMinHeight() {
        return YogaInterop.YGNodeStyleGetMinHeight(this).ToYogaValue();
    }
    
    public void StyleSetMinWidth(float minWidth) {
        YogaInterop.YGNodeStyleSetMinWidth(this, minWidth);
    }
    
    public void StyleSetMinWidthPercent(float minWidthPercent) {
        YogaInterop.YGNodeStyleSetMinWidthPercent(this, minWidthPercent);
    }
    
    public YogaValue StyleGetMaxWidth() {
        return YogaInterop.YGNodeStyleGetMaxWidth(this).ToYogaValue();
    }
    
    public void StyleSetMaxHeight(float minHeight) {
        YogaInterop.YGNodeStyleSetMaxHeight(this, minHeight);
    }
    
    public void StyleSetMaxHeightPercent(float minHeightPercent) {
        YogaInterop.YGNodeStyleSetMaxWidthPercent(this, minHeightPercent);
    }
    
    public YogaValue StyleGetMaxHeight() {
        return YogaInterop.YGNodeStyleGetMaxHeight(this).ToYogaValue();
    }
    
    public void StyleSetMaxWidth(float minWidth) {
        YogaInterop.YGNodeStyleSetMaxWidth(this, minWidth);
    }
    
    public void StyleSetMaxWidthPercent(float minWidthPercent) {
        YogaInterop.YGNodeStyleSetMaxWidthPercent(this, minWidthPercent);
    }

    public float AspectRatio {
        get => YogaInterop.YGNodeStyleGetAspectRatio(this);
        set => YogaInterop.YGNodeStyleSetAspectRatio(this, value);
    }
}