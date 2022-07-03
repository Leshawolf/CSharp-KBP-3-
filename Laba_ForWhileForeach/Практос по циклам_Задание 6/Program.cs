using System;

namespace Практос_по_циклам_Задание_6
{
    class Program
    {
        static void Main(string[] args)
        {
            double proc = (10 / 100.0) * 0.1;
            int c = 0;
            for(double i=10.0;i<20;i+=proc)
            {
                c++;
            }
            Console.WriteLine($"Через {c} дней он пробежит 20 км за раз");
        }
    }
}
