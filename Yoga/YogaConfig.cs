using Yoga.Interop;

namespace Yoga; 

public class YogaConfig : YogaBase {
    public unsafe YogaConfig(void* rawPointer) : base(rawPointer) { }

    public YogaConfig() {
        unsafe {
            RawPointer = YogaInterop.YGConfigNew();
        }
    }

    ~YogaConfig() {
        unsafe {
            YogaInterop.YGConfigFree(RawPointer);
        }
    }
}