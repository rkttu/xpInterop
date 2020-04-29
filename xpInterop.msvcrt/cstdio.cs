using System.Runtime.InteropServices;

namespace cstdio
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate int pinvoke_printf_1(string fmt, int arg0);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate int pinvoke_printf_2(string fmt, float arg0);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    internal delegate int pinvoke_scanf_1(string fmt, out int arg0);

    public static class Extension
    {
        public static int printf(this msvcrt lib, string fmt, int arg0)
            => lib.GetFunction<pinvoke_printf_1>("printf")(fmt, arg0);

        public static int printf(this msvcrt lib, string fmt, float arg0)
            => lib.GetFunction<pinvoke_printf_2>("printf")(fmt, arg0);

        public static int scanf(this msvcrt lib, string fmt, out int arg0)
            => lib.GetFunction<pinvoke_scanf_1>("scanf")(fmt, out arg0);
    }
}
