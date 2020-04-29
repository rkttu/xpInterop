using cstdio;
using cstring;
using System;

namespace NativeLibraryTest
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            using var lib = new msvcrt();

            var spot = DateTime.UtcNow;

            for (int i = 0; i < 1000; i++)
            {
                Console.Out.WriteLine($"strlen returns {lib.strlen("aaa")}");

                var result = lib.printf("Hello, World! %d\n", 123);
                Console.Out.WriteLine($"printf returns {result}");

                result = lib.printf("Hello, World! %f\n", 123f);
                Console.Out.WriteLine($"printf returns {result}");
            }

            var duration = DateTime.UtcNow - spot;

            Console.WriteLine($"Elapsed time: {duration}");
        }
    }
}
