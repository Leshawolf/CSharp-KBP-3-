using System;

namespace Задание_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите элемент x:");
            double x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите элемент n:");
            double n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"X^n = {Stepn(x,n)}");
        }
        static double Stepn(double x,double n)
        {
            if (n == 0)
            {
                Console.WriteLine("1");
                return 1;
            }
            else if (n < 0)
            {
                Console.WriteLine("N<0");
                return 1 / Stepn(x, Math.Abs(n));
            }
            else
            {
                Console.WriteLine("N>0");
                return x * Stepn(x, n - 1);
            }
        }
    }
}
