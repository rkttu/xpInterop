using System.Reflection;
using System.Runtime.InteropServices;
using xpInterop;

public sealed class msvcrt : ManagedNativeLibrary
{
    internal static readonly string DefaultLibraryPath = "msvcrt.dll";

    public msvcrt()
        : this(DefaultLibraryPath) { }

    public msvcrt(Assembly assembly, DllImportSearchPath? searchPath)
        : this(DefaultLibraryPath, assembly, searchPath) { }

    public msvcrt(string libraryPath)
        : base(libraryPath) { }

    public msvcrt(string libraryPath, Assembly assembly, DllImportSearchPath? searchPath)
        : base(libraryPath, assembly, searchPath) { }
}
