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
    
    private Node root;
    
    private Node child1;
    private Node child2;

    private Node child2_1;
    private Node child2_2;
    [SetUp]
    public void Setup() {
        YGConfig = new YogaConfig();
            
        root = new Node(YGConfig) {
            Height = 1000f,
            Width = 1000f,
            FlexDirection = FlexDirection.Row,
            AlignItems = Align.Baseline
        };
            
        child1 = new Node(YGConfig) {
            Height = 500f,
            Width = 600f,
            FlexDirection = FlexDirection.Column
        };
        root.Children.Add(child1);
        
        child2 = new Node(YGConfig) {
            Height = 500f,
            Width = 800f,
            FlexDirection = FlexDirection.Column
        };
        
        child2_1 = new Node(YGConfig) {
            Height = 500f,
            Width = 300f,
            FlexDirection = FlexDirection.Column
        };
        
        child2_2 = new Node(YGConfig) {
            Height = 500f,
            Width = 400f,
            FlexDirection = FlexDirection.Column
        };
        
        root.Children.Add(child2);
        
        child2.Children.Add(child2_1);
        child2.Children.Add(child2_2);
        
        unsafe {
            YogaInterop.YGNodeSetBaselineFunc(child2_2, &BaselineFunction);
        }
        
        child2_2.IsReferenceBaseline = true;
        
        root.CalculateLayout();
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