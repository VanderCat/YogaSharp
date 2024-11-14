using Yoga.Interop;
using ZeroElectric.Vinculum;

namespace Yoga.Tests.Visual; 

public class TestLayout : IScene {
    private Node _rootNode;
    public void Draw() {
        _rootNode.DrawBorder(Raylib.WHITE);
    }

    public void Update() {
        if (_rootNode.IsDirty) {
            _rootNode.CalculateLayout();
        }
    }

    public void Init() {
        _rootNode = new Node {
            Width = Raylib.GetRenderWidth(),
            Height = Raylib.GetRenderHeight(),
            FlexDirection = FlexDirection.Column
        };
        _rootNode.StyleSetBorder(Edge.All, 1);
        _rootNode.AlignItems = Align.Center;
        
        var mainNode = new Node {
            Parent = _rootNode,
            FlexDirection = FlexDirection.Row
        };
        mainNode.StyleSetWidthPercent(75);
        mainNode.StyleSetHeightPercent(100);
        mainNode.StyleSetBorder(Edge.All, 1);
        mainNode.StyleSetPadding(Edge.All, 8);
        mainNode.StyleSetGap(16);
        
        var LeftNode = new Node {
            Parent = mainNode,
            FlexShrink = 1
        };
        var RightNode = new Node {
            Parent = mainNode,
            FlexShrink = 1,
            Width = 256f
        };
        RightNode.StyleSetHeightPercent(100f);

        var vidNode = new Node {
            Parent = LeftNode,
            AspectRatio = 1.77f,
            FlexShrink = 1
        };
        vidNode.StyleSetWidthPercent(100f);
        vidNode.StyleSetBorder(Edge.All, 1);
        _rootNode.CalculateLayout();

        _rootNode.Print(PrintOptions.Children);
        vidNode.Print(PrintOptions.Layout);
        
        //var textNode = new TextNode {
        //    Parent = vidNode,
        //    Text = "omg hi!!!"
        //};

        //var vidSuggestion = new YogaNode() { };
    }
}