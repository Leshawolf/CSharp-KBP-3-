using System;

namespace Практос_по_циклам_Задание_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            if(a>=0)
            {
                double S = 1;
                for (int k=2;k<=30;k+=5)
                {
                    S *= (k + 10) / k;
                }
                Console.WriteLine($"S= {S}");
            }
            else
            {
                double S = 0;
                for (int k = 2; k <= 10; k += 2)
                {
                    S += Math.Pow(k,2)-3;
                }
                Console.WriteLine($"S= {S}");
            }
        }
    }
}
