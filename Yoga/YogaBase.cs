using Yoga.Interop;

namespace Yoga;

public abstract class YogaBase {
    public const float Undefined = YogaInterop.YGUndefined;
    public unsafe void* RawPointer { get; protected internal set; }

    public YogaBase() {}
    public unsafe YogaBase(void* rawPointer) {
        RawPointer = rawPointer;
    }
}