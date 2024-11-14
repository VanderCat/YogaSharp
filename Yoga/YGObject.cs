using System.Runtime.CompilerServices;
using Yoga.Interop;

namespace Yoga;

public unsafe abstract class YGObject<T> where T : YGObject<T>, new() {
    public const float Undefined = YogaInterop.YGUndefined;
    protected void* Pointer;
    
    internal static readonly Dictionary<nint, WeakReference<T>> __OBJECT_CACHE = new();
    
    protected YGObject() {}
    public YGObject(void* pointer) {
        Pointer = pointer;
    }
    
    
    public override bool Equals(object? obj)
    {
        if (obj is not YGObject<T> type)
            return false;
        return type.Pointer == Pointer;
    }
    
    public static implicit operator void*(YGObject<T> o) => o.Pointer;
    public static implicit operator nint(YGObject<T> o) => (nint)o.Pointer;
    public object? Context {
        get => __CONTEXT_CACHE.TryGetValue(this, out var result) ? result : null;
        set => __CONTEXT_CACHE[this] = value;
    }
    
    internal static Dictionary<nint, object?> __CONTEXT_CACHE = new();
}