using System.Runtime.InteropServices;
using static Yoga.Interop.YGUnit;

namespace Yoga.Interop;

public static unsafe partial class YogaInterop
{
    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("YGConfigRef")]
    public static extern void* YGConfigNew();

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGConfigFree([NativeTypeName("YGConfigRef")] void* config);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("YGConfigConstRef")]
    public static extern void* YGConfigGetDefault();

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGConfigSetUseWebDefaults([NativeTypeName("YGConfigRef")] void* config, bool enabled);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool YGConfigGetUseWebDefaults([NativeTypeName("YGConfigConstRef")] void* config);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGConfigSetPointScaleFactor([NativeTypeName("YGConfigRef")] void* config, float pixelsInPoint);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGConfigGetPointScaleFactor([NativeTypeName("YGConfigConstRef")] void* config);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGConfigSetErrata([NativeTypeName("YGConfigRef")] void* config, YGErrata errata);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGErrata YGConfigGetErrata([NativeTypeName("YGConfigConstRef")] void* config);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGConfigSetLogger([NativeTypeName("YGConfigRef")] void* config, [NativeTypeName("YGLogger")] delegate* unmanaged[Cdecl]<void*, void*, YGLogLevel, sbyte*, sbyte*, int> logger);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGConfigSetContext([NativeTypeName("YGConfigRef")] void* config, void* context);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void* YGConfigGetContext([NativeTypeName("YGConfigConstRef")] void* config);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGConfigSetExperimentalFeatureEnabled([NativeTypeName("YGConfigRef")] void* config, YGExperimentalFeature feature, bool enabled);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool YGConfigIsExperimentalFeatureEnabled([NativeTypeName("YGConfigConstRef")] void* config, YGExperimentalFeature feature);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGConfigSetCloneNodeFunc([NativeTypeName("YGConfigRef")] void* config, [NativeTypeName("YGCloneNodeFunc")] delegate* unmanaged[Cdecl]<void*, void*, nuint, void*> callback);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGConfigSetPrintTreeFlag([NativeTypeName("YGConfigRef")] void* config, bool enabled);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGAlignToString(YGAlign param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGDimensionToString(YGDimension param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGDirectionToString(YGDirection param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGDisplayToString(YGDisplay param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGEdgeToString(YGEdge param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGErrataToString(YGErrata param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGExperimentalFeatureToString(YGExperimentalFeature param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGFlexDirectionToString(YGFlexDirection param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGGutterToString(YGGutter param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGJustifyToString(YGJustify param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGLogLevelToString(YGLogLevel param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGMeasureModeToString(YGMeasureMode param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGNodeTypeToString(YGNodeType param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGOverflowToString(YGOverflow param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGPositionTypeToString(YGPositionType param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGPrintOptionsToString(YGPrintOptions param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGUnitToString(YGUnit param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("const char *")]
    public static extern sbyte* YGWrapToString(YGWrap param0);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("YGNodeRef")]
    public static extern void* YGNodeNew();

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("YGNodeRef")]
    public static extern void* YGNodeNewWithConfig([NativeTypeName("YGConfigConstRef")] void* config);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("YGNodeRef")]
    public static extern void* YGNodeClone([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeFree([NativeTypeName("YGNodeRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeFreeRecursive([NativeTypeName("YGNodeRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeFinalize([NativeTypeName("YGNodeRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeReset([NativeTypeName("YGNodeRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeCalculateLayout([NativeTypeName("YGNodeRef")] void* node, float availableWidth, float availableHeight, YGDirection ownerDirection);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool YGNodeGetHasNewLayout([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeSetHasNewLayout([NativeTypeName("YGNodeRef")] void* node, bool hasNewLayout);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool YGNodeIsDirty([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeMarkDirty([NativeTypeName("YGNodeRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeSetDirtiedFunc([NativeTypeName("YGNodeRef")] void* node, [NativeTypeName("YGDirtiedFunc")] delegate* unmanaged[Cdecl]<void*, void> dirtiedFunc);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("YGDirtiedFunc")]
    public static extern delegate* unmanaged[Cdecl]<void*, void> YGNodeGetDirtiedFunc([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeInsertChild([NativeTypeName("YGNodeRef")] void* node, [NativeTypeName("YGNodeRef")] void* child, [NativeTypeName("size_t")] nuint index);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeSwapChild([NativeTypeName("YGNodeRef")] void* node, [NativeTypeName("YGNodeRef")] void* child, [NativeTypeName("size_t")] nuint index);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeRemoveChild([NativeTypeName("YGNodeRef")] void* node, [NativeTypeName("YGNodeRef")] void* child);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeRemoveAllChildren([NativeTypeName("YGNodeRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeSetChildren([NativeTypeName("YGNodeRef")] void* owner, [NativeTypeName("const YGNodeRef *")] void** children, [NativeTypeName("size_t")] nuint count);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("YGNodeRef")]
    public static extern void* YGNodeGetChild([NativeTypeName("YGNodeRef")] void* node, [NativeTypeName("size_t")] nuint index);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("size_t")]
    public static extern nuint YGNodeGetChildCount([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("YGNodeRef")]
    public static extern void* YGNodeGetOwner([NativeTypeName("YGNodeRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("YGNodeRef")]
    public static extern void* YGNodeGetParent([NativeTypeName("YGNodeRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeSetConfig([NativeTypeName("YGNodeRef")] void* node, [NativeTypeName("YGConfigRef")] void* config);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [return: NativeTypeName("YGConfigConstRef")]
    public static extern void* YGNodeGetConfig([NativeTypeName("YGNodeRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeSetContext([NativeTypeName("YGNodeRef")] void* node, void* context);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void* YGNodeGetContext([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeSetMeasureFunc([NativeTypeName("YGNodeRef")] void* node, [NativeTypeName("YGMeasureFunc")] delegate* unmanaged[Cdecl]<void*, float, YGMeasureMode, float, YGMeasureMode, YGSize> measureFunc);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool YGNodeHasMeasureFunc([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeSetBaselineFunc([NativeTypeName("YGNodeRef")] void* node, [NativeTypeName("YGBaselineFunc")] delegate* unmanaged[Cdecl]<void*, float, float, float> baselineFunc);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool YGNodeHasBaselineFunc([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeSetIsReferenceBaseline([NativeTypeName("YGNodeRef")] void* node, bool isReferenceBaseline);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool YGNodeIsReferenceBaseline([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeSetNodeType([NativeTypeName("YGNodeRef")] void* node, YGNodeType nodeType);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGNodeType YGNodeGetNodeType([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeSetAlwaysFormsContainingBlock([NativeTypeName("YGNodeRef")] void* node, bool alwaysFormsContainingBlock);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodePrint([NativeTypeName("YGNodeConstRef")] void* node, YGPrintOptions options);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    [Obsolete("YGNodeCanUseCachedMeasurement may be removed in a future version of Yoga")]
    public static extern bool YGNodeCanUseCachedMeasurement(YGMeasureMode widthMode, float availableWidth, YGMeasureMode heightMode, float availableHeight, YGMeasureMode lastWidthMode, float lastAvailableWidth, YGMeasureMode lastHeightMode, float lastAvailableHeight, float lastComputedWidth, float lastComputedHeight, float marginRow, float marginColumn, [NativeTypeName("YGConfigRef")] void* config);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGNodeLayoutGetLeft([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGNodeLayoutGetTop([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGNodeLayoutGetRight([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGNodeLayoutGetBottom([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGNodeLayoutGetWidth([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGNodeLayoutGetHeight([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGDirection YGNodeLayoutGetDirection([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool YGNodeLayoutGetHadOverflow([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGNodeLayoutGetMargin([NativeTypeName("YGNodeConstRef")] void* node, YGEdge edge);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGNodeLayoutGetBorder([NativeTypeName("YGNodeConstRef")] void* node, YGEdge edge);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGNodeLayoutGetPadding([NativeTypeName("YGNodeConstRef")] void* node, YGEdge edge);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeCopyStyle([NativeTypeName("YGNodeRef")] void* dstNode, [NativeTypeName("YGNodeConstRef")] void* srcNode);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetDirection([NativeTypeName("YGNodeRef")] void* node, YGDirection direction);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGDirection YGNodeStyleGetDirection([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetFlexDirection([NativeTypeName("YGNodeRef")] void* node, YGFlexDirection flexDirection);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGFlexDirection YGNodeStyleGetFlexDirection([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetJustifyContent([NativeTypeName("YGNodeRef")] void* node, YGJustify justifyContent);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGJustify YGNodeStyleGetJustifyContent([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetAlignContent([NativeTypeName("YGNodeRef")] void* node, YGAlign alignContent);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGAlign YGNodeStyleGetAlignContent([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetAlignItems([NativeTypeName("YGNodeRef")] void* node, YGAlign alignItems);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGAlign YGNodeStyleGetAlignItems([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetAlignSelf([NativeTypeName("YGNodeRef")] void* node, YGAlign alignSelf);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGAlign YGNodeStyleGetAlignSelf([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetPositionType([NativeTypeName("YGNodeRef")] void* node, YGPositionType positionType);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGPositionType YGNodeStyleGetPositionType([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetFlexWrap([NativeTypeName("YGNodeRef")] void* node, YGWrap flexWrap);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGWrap YGNodeStyleGetFlexWrap([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetOverflow([NativeTypeName("YGNodeRef")] void* node, YGOverflow overflow);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGOverflow YGNodeStyleGetOverflow([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetDisplay([NativeTypeName("YGNodeRef")] void* node, YGDisplay display);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGDisplay YGNodeStyleGetDisplay([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetFlex([NativeTypeName("YGNodeRef")] void* node, float flex);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGNodeStyleGetFlex([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetFlexGrow([NativeTypeName("YGNodeRef")] void* node, float flexGrow);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGNodeStyleGetFlexGrow([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetFlexShrink([NativeTypeName("YGNodeRef")] void* node, float flexShrink);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGNodeStyleGetFlexShrink([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetFlexBasis([NativeTypeName("YGNodeRef")] void* node, float flexBasis);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetFlexBasisPercent([NativeTypeName("YGNodeRef")] void* node, float flexBasis);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetFlexBasisAuto([NativeTypeName("YGNodeRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGValue YGNodeStyleGetFlexBasis([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetPosition([NativeTypeName("YGNodeRef")] void* node, YGEdge edge, float position);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetPositionPercent([NativeTypeName("YGNodeRef")] void* node, YGEdge edge, float position);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGValue YGNodeStyleGetPosition([NativeTypeName("YGNodeConstRef")] void* node, YGEdge edge);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetMargin([NativeTypeName("YGNodeRef")] void* node, YGEdge edge, float margin);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetMarginPercent([NativeTypeName("YGNodeRef")] void* node, YGEdge edge, float margin);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetMarginAuto([NativeTypeName("YGNodeRef")] void* node, YGEdge edge);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGValue YGNodeStyleGetMargin([NativeTypeName("YGNodeConstRef")] void* node, YGEdge edge);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetPadding([NativeTypeName("YGNodeRef")] void* node, YGEdge edge, float padding);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetPaddingPercent([NativeTypeName("YGNodeRef")] void* node, YGEdge edge, float padding);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGValue YGNodeStyleGetPadding([NativeTypeName("YGNodeConstRef")] void* node, YGEdge edge);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetBorder([NativeTypeName("YGNodeRef")] void* node, YGEdge edge, float border);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGNodeStyleGetBorder([NativeTypeName("YGNodeConstRef")] void* node, YGEdge edge);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetGap([NativeTypeName("YGNodeRef")] void* node, YGGutter gutter, float gapLength);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGNodeStyleGetGap([NativeTypeName("YGNodeConstRef")] void* node, YGGutter gutter);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetWidth([NativeTypeName("YGNodeRef")] void* node, float width);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetWidthPercent([NativeTypeName("YGNodeRef")] void* node, float width);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetWidthAuto([NativeTypeName("YGNodeRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGValue YGNodeStyleGetWidth([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetHeight([NativeTypeName("YGNodeRef")] void* node, float height);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetHeightPercent([NativeTypeName("YGNodeRef")] void* node, float height);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetHeightAuto([NativeTypeName("YGNodeRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGValue YGNodeStyleGetHeight([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetMinWidth([NativeTypeName("YGNodeRef")] void* node, float minWidth);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetMinWidthPercent([NativeTypeName("YGNodeRef")] void* node, float minWidth);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGValue YGNodeStyleGetMinWidth([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetMinHeight([NativeTypeName("YGNodeRef")] void* node, float minHeight);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetMinHeightPercent([NativeTypeName("YGNodeRef")] void* node, float minHeight);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGValue YGNodeStyleGetMinHeight([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetMaxWidth([NativeTypeName("YGNodeRef")] void* node, float maxWidth);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetMaxWidthPercent([NativeTypeName("YGNodeRef")] void* node, float maxWidth);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGValue YGNodeStyleGetMaxWidth([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetMaxHeight([NativeTypeName("YGNodeRef")] void* node, float maxHeight);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetMaxHeightPercent([NativeTypeName("YGNodeRef")] void* node, float maxHeight);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern YGValue YGNodeStyleGetMaxHeight([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void YGNodeStyleSetAspectRatio([NativeTypeName("YGNodeRef")] void* node, float aspectRatio);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGNodeStyleGetAspectRatio([NativeTypeName("YGNodeConstRef")] void* node);

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern float YGRoundValueToPixelGrid(double value, double pointScaleFactor, bool forceCeil, bool forceFloor);

    [NativeTypeName("const float")]
    public const float YGUndefined = float.NaN;

    [DllImport("yoga", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern bool YGFloatIsUndefined(float value);

    public static bool Equals([NativeTypeName("const YGValue &")] YGValue* lhs, [NativeTypeName("const YGValue &")] YGValue* rhs)
    {
        if (lhs->unit != rhs->unit)
        {
            return false;
        }

        switch (lhs->unit)
        {
            case YGUnitUndefined:
            case YGUnitAuto:
            {
                return true;
            }

            case YGUnitPoint:
            case YGUnitPercent:
            {
                return lhs->value == rhs->value;
            }
        }

        return false;
    }

    public static bool NotEquals([NativeTypeName("const YGValue &")] YGValue* lhs, [NativeTypeName("const YGValue &")] YGValue* rhs)
    {
        return !(Equals(lhs, rhs));
    }

    public static YGValue Subtract([NativeTypeName("const YGValue &")] YGValue* value)
    {
        return new YGValue
        {
            value = -value->value,
            unit = value->unit,
        };
    }
}
