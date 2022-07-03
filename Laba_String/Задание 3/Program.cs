using System;
using static System.Convert;
using static System.Console;
using System.Linq;

namespace Задание_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = ReadLine();
            s = s.Replace(".",": ");
            s = s.Replace("-", ": ");
            WriteLine(s);
        }
    }
}
