using ZeroElectric.Vinculum;

namespace Yoga.Tests.Visual; 

public static class Extensions {
    public static void DrawBorder(this YogaNode node, Color color) {
        var borderTop = node.GetBorder(YogaEdge.Top);
        var borderBottom = node.GetBorder(YogaEdge.Bottom);
        var borderRight = node.GetBorder(YogaEdge.Right);
        var borderLeft = node.GetBorder(YogaEdge.Left);
        
        //Top
        Raylib.DrawRectangleRec(new Rectangle(node.Left, node.Top, node.Width, borderTop), color);
        //Left
        Raylib.DrawRectangleRec(new Rectangle(node.Left, node.Top, borderLeft, node.Height), color);
        //Right
        Raylib.DrawRectangleRec(new Rectangle(node.Left+node.Width-borderRight, node.Top, borderRight, node.Height), color);
        //Bottom
        Raylib.DrawRectangleRec(new Rectangle(node.Left, node.Top+node.Height-borderBottom, node.Width, borderBottom), color);
    }
}