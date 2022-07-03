using System;

namespace Практос_про_циклы_Задание_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, h;
            do {
                Console.Write("Введите начальное значение отрезка: ");
                a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите конечное значение отрезка: ");
                b = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите шаг: ");
                h = Convert.ToDouble(Console.ReadLine());
            }
            while (a>b || b<h);
            double zadanie;
            Console.WriteLine($"### Кординаты ### Вычисление по функции ###");
            while (a<=b)
            {
                
                zadanie = Math.Sin(a)/Math.Pow((Math.E),a);
                Console.WriteLine($"###    {a}  ### {zadanie} ###");
                a += h;

            }
        }
    }
}