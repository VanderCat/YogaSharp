using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using Yoga.Interop;

namespace Yoga; 

public class YogaConfig : YogaBase {

    public static YogaConfig Default { get; internal set;}
    public unsafe YogaConfig(void* rawPointer) : base(rawPointer) { }

    static YogaConfig() {
        Default = new YogaConfig();
    }

    public YogaConfig() {
        unsafe {
            RawPointer = YogaInterop.YGConfigNew();
        }
    }

    ~YogaConfig() {
        Free();
    }

    private void Free() {
        unsafe {
            YogaInterop.YGConfigFree(RawPointer);
        }
    }

    public bool UseWebDefaults {
        get {
            unsafe {
                return YogaInterop.YGConfigGetUseWebDefaults(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGConfigSetUseWebDefaults(RawPointer, value);
            }
        }
    }
    
    public float PointScaleFactor {
        get {
            unsafe {
                return YogaInterop.YGConfigGetPointScaleFactor(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGConfigSetPointScaleFactor(RawPointer, value);
            }
        }
    }
    
    public Errata Errata {
        get {
            unsafe {
                return (Errata)YogaInterop.YGConfigGetErrata(RawPointer);
            }
        }
        set {
            unsafe {
                YogaInterop.YGConfigSetErrata(RawPointer, (YGErrata)value);
            }
        }
    }

    public object? Context;

    private GCHandle? _contextHandle;
    
    [Obsolete(
        "I don't know why would you use that but if you know what you are doing i'm not stopping you (unlike me)")]
    public void SetUnmanagedContext<T>(T context) {
        _contextHandle?.Free();

        _contextHandle = GCHandle.Alloc(context, GCHandleType.Pinned);
        if (_contextHandle is not null)
            unsafe {
                YogaInterop.YGNodeSetContext(RawPointer, _contextHandle.Value.AddrOfPinnedObject().ToPointer());
                return;
            }
    }

    [Obsolete(
        "I don't know why would you use that but if you know what you are doing i'm not stopping you (unlike me)")]
    public T GetUnmanagedContext<T>() {
        unsafe {
            var ptr = YogaInterop.YGNodeGetContext(RawPointer);
            var method = new DynamicMethod("ConvertPtrToObjReference", typeof(T),
                new[] {typeof(void*)});
            var gen = method.GetILGenerator();
            gen.Emit(OpCodes.Ldarg_0);
            gen.Emit(OpCodes.Ret);
            return (T) method.Invoke(null, BindingFlags.Default, null, new[] {(object) new IntPtr(ptr)}, null);
        }
    }

    public void SetExperimentalFeatureEnabled(YogaExperimentalFeature feature, bool enabled) {
        unsafe {
            YogaInterop.YGConfigSetExperimentalFeatureEnabled(RawPointer, (YGExperimentalFeature)feature, enabled);
        }
    }
    
    public bool IsExperimentalFeatureEnabled(YogaExperimentalFeature feature) {
        unsafe {
            return YogaInterop.YGConfigIsExperimentalFeatureEnabled(RawPointer, (YGExperimentalFeature)feature);
        }
    }
    
    public delegate int YogaLoggingFunction(YogaConfig config, IntPtr node, LogLevel logLevel,
        string format, string[] args);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private unsafe delegate int YGLoggingFunction(void* config, void* node, YGLogLevel logLevel, sbyte* format, sbyte* args);

    private YogaLoggingFunction? _loggingFunction;

    public YogaLoggingFunction? MeasureFunction {
        get => _loggingFunction;
        set {
            unsafe {
                _loggingFunction = value;
                if (_loggingFunction is null) {
                    YogaInterop.YGConfigSetLogger(RawPointer, null);
                    return;
                }

                YGLoggingFunction unmanaged = (config, node, logLevel, format, args) => {
                    var result = _loggingFunction(this, new IntPtr(node), (LogLevel)logLevel, format->ToString(), new[] {args->ToString()});
                    return result; //FIXME: how do we handle varargs?
                };

                YogaInterop.YGConfigSetLogger(RawPointer,
#pragma warning disable CS8500
                    (delegate* unmanaged[Cdecl]<void*, void*, YGLogLevel, sbyte*, sbyte*, int>) &unmanaged);
#pragma warning restore CS8500
            }
        }
    }
}