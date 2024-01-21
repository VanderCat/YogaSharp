using System.Reflection;
using System.Runtime.InteropServices;

namespace Yoga.Interop; 

internal static class DllSearch {

    const string NativeLib = "yogacore";

    static DllSearch()
    {
        NativeLibrary.SetDllImportResolver(typeof(DllSearch).Assembly, ImportResolver);
    }

    private static IntPtr ImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        var libHandle = IntPtr.Zero;
        if (libraryName == NativeLib)
            NativeLibrary.TryLoad($"./{libraryName}.dll", out libHandle);
        return libHandle;
    }
}