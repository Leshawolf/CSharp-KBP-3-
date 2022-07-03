using System;

namespace Практос_по_циклам_Задание_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите значение n: ");
            double n = Convert.ToDouble(Console.ReadLine());

            double y = 0;
            double y2 = 0;
            for (int i=0; i>=0;i--)
            {
                y += n--;
                y2 += Math.Sqrt(y);
            }
            Console.Write($"Y= {y2}");
        }
    }
}
