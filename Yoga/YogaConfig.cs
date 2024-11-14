using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using Yoga.Interop;

namespace Yoga; 

public unsafe class YogaConfig : YGObject<YogaConfig> {

    public static YogaConfig Default { get; internal set;}
    public unsafe YogaConfig(void* pointer) : base(pointer) { }

    static YogaConfig() {
        Default = new YogaConfig();
    }

    public YogaConfig() {
        Pointer = YogaInterop.YGConfigNew();
    }

    ~YogaConfig() {
        Free();
    }

    private void Free() {
        YogaInterop.YGConfigFree(this);
    }

    public bool UseWebDefaults {
        get {
            return YogaInterop.YGConfigGetUseWebDefaults(this);
        }
        set {
            YogaInterop.YGConfigSetUseWebDefaults(this, value);
        }
    }
    
    public float PointScaleFactor {
        get {
            return YogaInterop.YGConfigGetPointScaleFactor(this);
        }
        set {
            YogaInterop.YGConfigSetPointScaleFactor(this, value);
        }
    }
    
    public Errata Errata {
        get {
            return (Errata)YogaInterop.YGConfigGetErrata(this);
        }
        set {
            YogaInterop.YGConfigSetErrata(this, (YGErrata)value);
        }
    }

    public void SetExperimentalFeatureEnabled(YogaExperimentalFeature feature, bool enabled) {
        YogaInterop.YGConfigSetExperimentalFeatureEnabled(this, (YGExperimentalFeature)feature, enabled);
    }
    
    public bool IsExperimentalFeatureEnabled(YogaExperimentalFeature feature) {
        return YogaInterop.YGConfigIsExperimentalFeatureEnabled(this, (YGExperimentalFeature)feature);
    }
    
    public delegate int YogaLoggingFunction(YogaConfig config, IntPtr node, LogLevel logLevel,
        string format, string[] args);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate int YGLoggingFunction(void* config, void* node, YGLogLevel logLevel, sbyte* format, sbyte* args);

    private YogaLoggingFunction? _loggingFunction;

    public YogaLoggingFunction? MeasureFunction {
        get => _loggingFunction;
        set {
            _loggingFunction = value;
            if (_loggingFunction is null) {
                YogaInterop.YGConfigSetLogger(this, null);
                return;
            }

            YGLoggingFunction unmanaged = (config, node, logLevel, format, args) => {
                var result = _loggingFunction(this, new IntPtr(node), (LogLevel)logLevel, format->ToString(), new[] {args->ToString()});
                return result; //FIXME: how do we handle varargs?
            };

            YogaInterop.YGConfigSetLogger(this,
#pragma warning disable CS8500
                (delegate* unmanaged[Cdecl]<void*, void*, YGLogLevel, sbyte*, sbyte*, int>) &unmanaged);
#pragma warning restore CS8500
        }
    }
}