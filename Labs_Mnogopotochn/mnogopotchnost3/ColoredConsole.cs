using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnogopot3
{
    internal class ColoredConsole
    {
        private static object locker = new();
        public static void WriteLine(ConsoleColor color, String format, params object[] list)
        {
            lock (locker)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(format, list);
                Console.ResetColor();
            }
        }
        public static void Write(ConsoleColor color, String format, params object[] list)
        {
            lock (locker)
            {
                Console.ForegroundColor = color;
                Console.Write(format, list);
                Console.ResetColor();
            }
        }

        public static void WriteRed(object o)
        {
            ColoredConsole.WriteLine(ConsoleColor.Red, "Red", 0);
        }
        public static void WriteGreen(object o)
        {
            ColoredConsole.WriteLine(ConsoleColor.Green, "Green", 0);
        }

        static void ClockTick(object o)
        {
            ConsoleColor c = (ConsoleColor)o;
            ColoredConsole.Write(c, "{0} ", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
