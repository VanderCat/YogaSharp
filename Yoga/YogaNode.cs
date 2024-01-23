using System.Collections;
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

    internal YogaNode _owner;
    public YogaNode Owner {
        get => _owner;
        set => value.Children.Add(this);
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

    public YogaPositionType PositionType {
        get {
            unsafe {
                return (YogaPositionType)YogaInterop.YGNodeStyleGetPositionType(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGNodeStyleSetPositionType(RawPointer, (YGPositionType)value);
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

    public YogaValue StyleGetPosition(YogaEdge edge) {
        unsafe {
            return YogaInterop.YGNodeStyleGetPosition(RawPointer, (YGEdge)edge).ToYogaValue();
        }
    }
    public void StyleSetPosition(YogaEdge edge, float position) {
        unsafe {
            YogaInterop.YGNodeStyleSetPosition(RawPointer, (YGEdge)edge, position);
        }
    }
    public void StyleSetPositionPercent(YogaEdge edge, float position) {
        unsafe {
            YogaInterop.YGNodeStyleSetPositionPercent(RawPointer, (YGEdge)edge, position);
        }
    }
    
    public YogaValue StyleGetMargin(YogaEdge edge) {
        unsafe {
            return YogaInterop.YGNodeStyleGetMargin(RawPointer, (YGEdge)edge).ToYogaValue();
        }
    }
    public void StyleSetMargin(YogaEdge edge, float margin) {
        unsafe {
            YogaInterop.YGNodeStyleSetMargin(RawPointer, (YGEdge)edge, margin);
        }
    }
    public void StyleSetMarginAuto(YogaEdge edge) {
        unsafe {
            YogaInterop.YGNodeStyleSetMarginAuto(RawPointer, (YGEdge)edge);
        }
    }
    public void StyleSetMarginPercent(YogaEdge edge, float margin) {
        unsafe {
            YogaInterop.YGNodeStyleSetMarginPercent(RawPointer, (YGEdge)edge, margin);
        }
    }
    public YogaValue StyleGetPadding(YogaEdge edge) {
        unsafe {
            return YogaInterop.YGNodeStyleGetPadding(RawPointer, (YGEdge)edge).ToYogaValue();
        }
    }
    public void StyleSetPadding(YogaEdge edge, float padding) {
        unsafe {
            YogaInterop.YGNodeStyleSetPadding(RawPointer, (YGEdge)edge, padding);
        }
    }
    public void StyleSetPaddingPercent(YogaEdge edge, float padding) {
        unsafe {
            YogaInterop.YGNodeStyleSetPaddingPercent(RawPointer, (YGEdge)edge, padding);
        }
    }
    public float StyleGetBorder(YogaEdge edge) {
        unsafe {
            return YogaInterop.YGNodeStyleGetBorder(RawPointer, (YGEdge)edge);
        }
    }
    public float GetBorder(YogaEdge edge) {
        unsafe {
            return YogaInterop.YGNodeLayoutGetBorder(RawPointer, (YGEdge)edge);
        }
    }
    public void StyleSetBorder(YogaEdge edge, float border) {
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
}