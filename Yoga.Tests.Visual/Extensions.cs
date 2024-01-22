using ZeroElectric.Vinculum;

namespace Yoga.Tests.Visual; 

public static class Extensions {
    public static void DrawBorder(this YogaNode node, Color color) {
        var borderTop = node.StyleGetBorder(YogaEdge.Top);
        var borderBottom = node.StyleGetBorder(YogaEdge.Bottom);
        var borderRight = node.StyleGetBorder(YogaEdge.Right);
        var borderLeft = node.StyleGetBorder(YogaEdge.Left);
        
        Raylib.DrawRectangleRec(new Rectangle(node.Left, node.Right-borderTop, node.Width, borderTop), color);
        Raylib.DrawRectangleRec(new Rectangle(node.Left, node.Bottom, node.Width, borderBottom), color);
        Raylib.DrawRectangleRec(new Rectangle(node.Left, node.Right, borderLeft, node.Height), color);
        Raylib.DrawRectangleRec(new Rectangle(node.Right-borderRight, node.Right, borderRight, node.Height), color);
    }
}