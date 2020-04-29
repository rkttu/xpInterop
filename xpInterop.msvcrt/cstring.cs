using System.Runtime.InteropServices;

namespace cstring
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate int pinvoke_strlen(string str);

    public static class Extension
    {
        public static int strlen(this msvcrt lib, string str)
            => lib.GetFunction<pinvoke_strlen>("strlen")(str);
    }
}
