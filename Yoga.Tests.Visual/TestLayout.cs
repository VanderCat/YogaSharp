using Yoga.Interop;
using ZeroElectric.Vinculum;

namespace Yoga.Tests.Visual; 

public class TestLayout : IScene {
    private YogaNode _rootNode;
    public void Draw() {
        _rootNode.DrawBorder(Raylib.WHITE);
        foreach (var child in _rootNode.Children) {
            child.DrawBorder(Raylib.GOLD);
        }
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
        
        var extraNode = new YogaNode {
            Parent = _rootNode
        };
        extraNode.StyleSetWidthPercent(75);
        extraNode.StyleSetHeightPercent(100);
        extraNode.StyleSetBorder(YogaEdge.All, 4);

        var funnyNode = new YogaNode {
            Width = 400,
            Height = 200,
            Parent = extraNode
        };
        funnyNode.StyleSetBorder(YogaEdge.All, 4);
        _rootNode.CalculateLayout();

        _rootNode.Print(YogaPrintOptions.Children);
        funnyNode.Print(YogaPrintOptions.Layout);
    }
}