using Yoga.Interop;
using ZeroElectric.Vinculum;

namespace Yoga.Tests.Visual; 

public class TestLayout : IScene {
    private YogaNode _rootNode;
    public void Draw() {
        _rootNode.DrawBorder(Raylib.WHITE);
    }

    public void Update() {
        if (_rootNode.IsDirty) {
            _rootNode.CalculateLayout();
        }
    }

    public void Init() {
        _rootNode = new YogaNode {
            Width = Raylib.GetRenderWidth(),
            Height = Raylib.GetRenderHeight(),
            FlexDirection = YogaFlexDirection.Column
        };
        _rootNode.StyleSetBorder(YogaEdge.All, 1);
        _rootNode.AlignItems = YogaAlign.Center;
        
        var mainNode = new YogaNode {
            Parent = _rootNode,
            FlexDirection = YogaFlexDirection.Row
        };
        mainNode.StyleSetWidthPercent(75);
        mainNode.StyleSetHeightPercent(100);
        mainNode.StyleSetBorder(YogaEdge.All, 1);
        mainNode.StyleSetPadding(YogaEdge.All, 8);
        mainNode.StyleSetGap(16);
        
        var LeftNode = new YogaNode {
            Parent = mainNode,
            FlexShrink = 1
        };
        var RightNode = new YogaNode {
            Parent = mainNode,
            FlexShrink = 1,
            Width = 256f
        };
        RightNode.StyleSetHeightPercent(100f);

        var vidNode = new YogaNode {
            Parent = LeftNode,
            AspectRatio = 1.77f,
            FlexShrink = 1
        };
        vidNode.StyleSetWidthPercent(100f);
        vidNode.StyleSetBorder(YogaEdge.All, 1);
        _rootNode.CalculateLayout();

        _rootNode.Print(YogaPrintOptions.Children);
        vidNode.Print(YogaPrintOptions.Layout);
        
        //var textNode = new TextNode {
        //    Parent = vidNode,
        //    Text = "omg hi!!!"
        //};

        //var vidSuggestion = new YogaNode() { };
    }
}