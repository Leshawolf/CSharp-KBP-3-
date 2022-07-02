using System;

namespace Задание_2_Лаба_2
{
    using static System.Console;
    using static System.Math;
    using static System.Convert;
    class Program
    {
        static void Main(string[] args)
        {
            Write("Введите ваше значение x:");
            double x = ToDouble(ReadLine());
            Write("Введите ваше значение y:");
            double y = ToDouble(ReadLine());
            Write("Введите Радиус окружности: ");
            double R = ToDouble(ReadLine());

            if ((Pow(x, 2) + Pow(y, 2) <= Pow(R, 2)) && (x >= 0) && (y >= 0))
            {
                WriteLine("Попало");
            }
            else if ((Pow(x, 2) + Pow(y, 2) <= Pow(R, 2)) && (y <= 0) && (x <= 0))
            {
                WriteLine("Попало");
            }
            else if (y <= x+R && x >= -R && y <= R && x<=0 && y>=0 )
            {
                WriteLine("Попало");
            }
            else
            {
                WriteLine("Не входит ваше число в нужное место");
            }
        }
    }
}