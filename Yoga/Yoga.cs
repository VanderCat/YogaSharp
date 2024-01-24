using Yoga.Interop;

namespace Yoga; 

public static class Yoga {
    public static float Undefined = float.NaN;
    
    public static float RoundValueToPixelGrid(double value, double pointScaleFactor, bool forceCeil, bool forceFloor) {
        return YogaInterop.YGRoundValueToPixelGrid(value, pointScaleFactor, forceCeil, forceFloor);
    }
}