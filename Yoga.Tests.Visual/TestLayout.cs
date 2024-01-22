using ZeroElectric.Vinculum;

namespace Yoga.Tests.Visual; 

public class TestLayout : IScene {
    private YogaNode _rootNode = new YogaNode();
    public void Draw() {
        _rootNode.DrawBorder(Raylib.WHITE);
    }

    public void Update() {
        
    }

    public void Init() {
        _rootNode.Width = 512;//Raylib.GetRenderWidth();
        _rootNode.Height = 512;//Raylib.GetRenderHeight();
        _rootNode.FlexDirection = YogaFlexDirection.Column;
        _rootNode.StyleSetBorder(YogaEdge.All, 64);
        var extraNode = new YogaNode();
        extraNode.Width = 100;
        extraNode.Height = 200;
        _rootNode.Children.Add(extraNode);
    }
}