using System;
using static System.Convert;
using static System.Console;
using System.Linq;
namespace Задание_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "радиовещание";
            char a = 'р',a1='о',a2='щ',a3='а';
            int indexOfChar = s.IndexOf(a);
            int indexOfChar1 = s.IndexOf(a1);
            int indexOfChar2 = s.IndexOf(a2);
            int indexOfChar3 = s.IndexOf(a3);
            if (indexOfChar==0)
            {
                if (indexOfChar1>=0)
                {
                    if (indexOfChar2 >= 0)
                    {
                        if (indexOfChar3 >= 0)
                        {
                            Console.WriteLine("Роща");
                        }
                    }
                }
            }
        }
    }
}
