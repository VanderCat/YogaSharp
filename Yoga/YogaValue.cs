using Yoga.Interop;

namespace Yoga; 

public struct YogaValue {
    public float Value;
    public YogaUnit Unit;

    public static implicit operator float(YogaValue v) => v.Value;

    internal static YogaValue FromYGValue(YGValue value) {
        return new YogaValue {
            Value = value.value,
            Unit = (YogaUnit)value.unit
        };
    }
    
    internal static YGValue ToYGValue(YogaValue value) {
        return new YGValue {
            value = value.Value,
            unit = (YGUnit)value.Unit
        };
    }
}