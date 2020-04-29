using System;

namespace xpInterop
{
    public interface IManagedNativeLibrary : IDisposable
    {
        IntPtr GetExport(string exportedName);
        T GetFunction<T>(string exportedName) where T : Delegate;
    }
}