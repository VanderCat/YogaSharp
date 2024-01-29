using System.Numerics;
using ZeroElectric.Vinculum;

namespace Yoga.Tests.Visual; 

public static class Extensions {
    public static void DrawBorder(this YogaNode node, Color color, float offsetX = 0, float offsetY = 0) {
        var borderTop = node.GetBorder(YogaEdge.Top);
        var borderBottom = node.GetBorder(YogaEdge.Bottom);
        var borderRight = node.GetBorder(YogaEdge.Right);
        var borderLeft = node.GetBorder(YogaEdge.Left);
        
        //Top
        Raylib.DrawRectangleRec(new Rectangle(node.Left+offsetX, node.Top+offsetY, node.Width, borderTop), color);
        //Left
        Raylib.DrawRectangleRec(new Rectangle(node.Left+offsetX, node.Top+offsetY, borderLeft, node.Height), color);
        //Right
        Raylib.DrawRectangleRec(new Rectangle(node.Left+node.Width-borderRight+offsetX, node.Top+offsetY, borderRight, node.Height), color);
        //Bottom
        Raylib.DrawRectangleRec(new Rectangle(node.Left+offsetX, node.Top+node.Height-borderBottom+offsetY, node.Width, borderBottom), color);
        foreach (var child in node.Children) {
            if (child.Type == YogaNodeType.Default)
                child.DrawBorder(Raylib.ColorAlpha(color, 0.99f), offsetX+node.Left, offsetY+node.Top);
            else
                ((TextNode)child).Draw(new Vector2(offsetX+node.Left, offsetY+node.Top));
        }
    }

    public static List<int> GetAllIndexOf(this string str) {
        var foundIndexes = new List<int>();

        for (var i = 0; i < str.Length; i++)
            if (str[i] == 'a') foundIndexes.Add(i);
        return foundIndexes;
    }
    
    public static string ReplaceAt(this string input, int index, char newChar)
    {
        if (input == null)
        {
            throw new ArgumentNullException("input");
        }
        char[] chars = input.ToCharArray();
        chars[index] = newChar;
        return new string(chars);
    }
}