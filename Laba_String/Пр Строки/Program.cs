using System;
using static System.Convert;
using static System.Console;
using System.Linq;
namespace Пр_Строки
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = ReadLine();
            var arr = s.ToCharArray();
            var a = arr.Distinct();
            foreach (var z in a)
            {
                Console.WriteLine($"Буква {z} повторяется {s.Count(c => c == z)} раз");
            }
        }
    }
}
