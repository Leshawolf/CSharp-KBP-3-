using System;

namespace Задание_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите P: ");
            double p=Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите А: ");
            double a = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Y= {Raschet(p,a)}");
        }
        static double Raschet(double p, double a)
        {
            return (p + a) / (Factorial(p) + a);
        }
        static double Factorial(double x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
    }
}
