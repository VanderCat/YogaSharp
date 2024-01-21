using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Yoga.Tests; 

[TestFixture]
public class YGSharpAlignBaselineTest {
    
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    private static unsafe float BaselineFunction(void* node, float width, float height)
    {
        return height / 2;
    }
    
    private YogaConfig YGConfig;
    
    private YogaNode root;
    
    private YogaNode child1;
    private YogaNode child2;

    private YogaNode child2_1;
    private YogaNode child2_2;
    [SetUp]
    public void Setup() {
        YGConfig = new YogaConfig();
            
        root = new YogaNode(YGConfig) {
            Height = 1000f,
            Width = 1000f,
            FlexDirection = YogaFlexDirection.Row,
            AlignItems = YogaAlign.Baseline
        };
            
        child1 = new YogaNode(YGConfig) {
            Height = 500f,
            Width = 600f,
            FlexDirection = YogaFlexDirection.Column
        };
        
        child2 = new YogaNode(YGConfig) {
            Height = 500f,
            Width = 800f,
            FlexDirection = YogaFlexDirection.Column
        };
        
        child2_1 = new YogaNode(YGConfig) {
            Height = 500f,
            Width = 300f,
            FlexDirection = YogaFlexDirection.Column
        };
        
        child2_2 = new YogaNode(YGConfig) {
            Height = 500f,
            Width = 400f,
            FlexDirection = YogaFlexDirection.Column
        };
        
        child2_2.IsReferenceBaseline = true;
        
        root.CalculateLayout();
        
        unsafe {
            YogaInterop.YGNodeInsertChild(root.RawPointer, child1.RawPointer, new UIntPtr(0));
            YogaInterop.YGNodeInsertChild(root.RawPointer, child2.RawPointer, new UIntPtr(1));
            YogaInterop.YGNodeInsertChild(child2.RawPointer, child2_1.RawPointer, new UIntPtr(0));
            
            YogaInterop.YGNodeSetBaselineFunc(child2_2.RawPointer, &BaselineFunction);
            YogaInterop.YGNodeInsertChild(child2.RawPointer, child2_2.RawPointer, new UIntPtr(1));
        }
    }

    [Test]
    public void Child1() {
        Assert.Multiple(() =>
        {
            Assert.That(child1.Left, Is.EqualTo(0f));
            Assert.That(child1.Top, Is.EqualTo(0f));
        });
        Assert.Multiple(() =>
        {
            Assert.That(child2.Left, Is.EqualTo(500f));
            Assert.That(child2.Top, Is.EqualTo(100f));
        });
        Assert.Multiple(() =>
        {
            Assert.That(child2_1.Left, Is.EqualTo(0f));
            Assert.That(child2_1.Top, Is.EqualTo(0f));
        });
        Assert.Multiple(() =>
        {
            Assert.That(child2_2.Left, Is.EqualTo(0f));
            Assert.That(child2_2.Top, Is.EqualTo(300f));
        });
    }
}