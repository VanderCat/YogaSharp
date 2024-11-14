using System.Drawing;
using System.Numerics;
using ZeroElectric.Vinculum;
using Color = ZeroElectric.Vinculum.Color;

namespace Yoga.Tests.Visual; 

public class TextNode : Node {
    private string _text = "";
    public string Text {
        get => _text;
        set {
            IsDirty = true;
            _text = value;
        }
    }
    private Font _font = Raylib.GetFontDefault();
    public Font Font {
        get => _font;
        set {
            IsDirty = true;
            _font = value;
        }
    }
    private float _fontSize = 16;
    public float FontSize {
        get => _fontSize;
        set {
            IsDirty = true;
            _fontSize = value;
        }
    }
    private float _fontSpacing = 1;
    public float FontSpacing {
        get => _fontSpacing;
        set {
            IsDirty = true;
            _fontSpacing = value;
        }
    }
    private string _wrappedText = "";

    public Color FontColor = Raylib.WHITE;
    
    public TextNode() : this(YogaConfig.Default) {
    }
    public TextNode(YogaConfig config) : base(config) {
        Type = NodeType.Text;
        MeasureFunction = TextMeasureFunction;
    }

    Vector2 CalculateWrappedText(float maxWidth) {
        var lines = Text.Split('\n');
        var doneLines = new string[lines.Length];
        var lineCounter = 0;
        foreach (var line in lines) {
            var spaceIndex = line.GetAllIndexOf();
            var toReplace = spaceIndex.Count;
            var result = Raylib.MeasureTextEx(Font, line, FontSize, FontSpacing);
            if (toReplace <= 0) {
                doneLines[lineCounter++] = line;
                continue;
            }
            var newLine = "";
            while (result.X > maxWidth) {
                if (toReplace <= 0) break;
                newLine = line.ReplaceAt(toReplace--, '\n');
                result = Raylib.MeasureTextEx(Font, newLine, FontSize, FontSpacing);
            }

            doneLines[lineCounter++] = newLine;
        }

        _wrappedText = string.Join('\n', doneLines);
        return Raylib.MeasureTextEx(Font, _wrappedText, FontSize, FontSpacing);
    }

    SizeF TextMeasureFunction(Node node, float width, MeasureMode widthMode,
        float height, MeasureMode heightMode) {
        var measurement = CalculateWrappedText(width);

        return new SizeF(width, measurement.Y);
    }

    public void Draw(Vector2 position) {
        Raylib.DrawTextEx(Font, _wrappedText, position, FontSize, FontSpacing, FontColor);
    }
}