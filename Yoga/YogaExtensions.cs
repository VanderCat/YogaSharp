using Yoga.Interop;

namespace Yoga; 

public static class YogaExtensions {
    internal static YGValue ToYGValue(this YogaValue yogaValue) {
        return YogaValue.ToYGValue(yogaValue);
    }
    internal static YogaValue ToYogaValue(this YGValue ygValue) {
        return YogaValue.FromYGValue(ygValue);
    }
}