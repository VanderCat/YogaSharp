using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Yoga.Tests;

public class Tests {

    private unsafe void* YGConfig;
    private unsafe void* root;
    private unsafe void* child1;
    private unsafe void* child2;
    private unsafe void* child2_child1;
    private unsafe void* child2_child2;
    
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe float BaselineFunction(void* node, float width, float height)
    {
        return height / 2;
    }
    

    private unsafe void* CreateNode(void* config, YGFlexDirection direction, float width, float height, bool alignBaseline) {
        var node = YogaInterop.YGNodeNewWithConfig(config);
        YogaInterop.YGNodeStyleSetFlexDirection(node, direction);
        YogaInterop.YGNodeStyleSetWidth(node, width);
        YogaInterop.YGNodeStyleSetHeight(node, height);
        if (alignBaseline) {
            YogaInterop.YGNodeStyleSetAlignItems(node, YGAlign.YGAlignBaseline);
        }

        return node;
    }

    [SetUp]
    public void Setup() {
        unsafe {
            YGConfig = YogaInterop.YGConfigNew();
            root = CreateNode(YGConfig, YGFlexDirection.YGFlexDirectionRow, 1000f, 1000f, true);
            
            child1 = CreateNode(YGConfig, YGFlexDirection.YGFlexDirectionColumn, 500f, 600f, false);
            YogaInterop.YGNodeInsertChild(root, child1, new UIntPtr(0));
            
            child2 = CreateNode(YGConfig, YGFlexDirection.YGFlexDirectionColumn, 500f, 800f, false);
            YogaInterop.YGNodeInsertChild(root, child2, new UIntPtr(1));
            
            child2_child1 = CreateNode(YGConfig, YGFlexDirection.YGFlexDirectionColumn, 500f, 300f, false);
            YogaInterop.YGNodeInsertChild(child2, child2_child1, new UIntPtr(0));
            
            child2_child2 = CreateNode(YGConfig, YGFlexDirection.YGFlexDirectionColumn, 500f, 400f, false);
            YogaInterop.YGNodeSetBaselineFunc(child2_child2, &BaselineFunction);
            YogaInterop.YGNodeSetIsReferenceBaseline(child2_child2, true);
            YogaInterop.YGNodeInsertChild(child2, child2_child2, new UIntPtr(1));
            
            YogaInterop.YGNodeCalculateLayout(root, YogaInterop.YGUndefined, YogaInterop.YGUndefined, YGDirection.YGDirectionInherit);
        }
    }

    [Test]
    public void Child1() {
        unsafe
        {
            Assert.Multiple(() =>
            {
                Assert.That(YogaInterop.YGNodeLayoutGetLeft(child1), Is.EqualTo(0f));
                Assert.That(YogaInterop.YGNodeLayoutGetTop(child1), Is.EqualTo(0f));
            });
            Assert.Multiple(() =>
            {
                Assert.That(YogaInterop.YGNodeLayoutGetLeft(child2), Is.EqualTo(500f));
                Assert.That(YogaInterop.YGNodeLayoutGetTop(child2), Is.EqualTo(100f));
            });
            Assert.Multiple(() =>
            {
                Assert.That(YogaInterop.YGNodeLayoutGetLeft(child2_child1), Is.EqualTo(0f));
                Assert.That(YogaInterop.YGNodeLayoutGetTop(child2_child1), Is.EqualTo(0f));
            });
            Assert.Multiple(() =>
            {
                Assert.That(YogaInterop.YGNodeLayoutGetLeft(child2_child2), Is.EqualTo(0f));
                Assert.That(YogaInterop.YGNodeLayoutGetTop(child2_child2), Is.EqualTo(300f));
            });
        }
    }

    [TearDown]
    public void Cleanup() {
        unsafe {
            YogaInterop.YGConfigFree(YGConfig);
            YogaInterop.YGNodeFree(root);
            YogaInterop.YGNodeFree(child1);
            YogaInterop.YGNodeFree(child2);
            YogaInterop.YGNodeFree(child2_child1);
            YogaInterop.YGNodeFree(child2_child2);
        }
    }
}