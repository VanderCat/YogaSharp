using Yoga.Interop;

namespace Yoga; 

public struct YogaValue {
    public float Value;
    public Unit Unit;

    public static implicit operator float(YogaValue v) => v.Value;

    internal static YogaValue FromYGValue(YGValue value) {
        return new YogaValue {
            Value = value.value,
            Unit = (Unit)value.unit
        };
    }
    
    internal static YGValue ToYGValue(YogaValue value) {
        return new YGValue {
            value = value.Value,
            unit = (YGUnit)value.Unit
        };
    }

    public static readonly YogaValue Auto = new() {
        Value = 0,
        Unit = Unit.Auto
    };

    public static readonly YogaValue Undefined = new() {
        Value = Yoga.Undefined,
        Unit = Unit.Undefined
    };
    
    public static readonly YogaValue Zero = new() {
        Value = 0,
        Unit = Unit.Point
    };

}