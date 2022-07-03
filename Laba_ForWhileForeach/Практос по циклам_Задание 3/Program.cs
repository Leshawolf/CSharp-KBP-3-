using System;

namespace Практос_по_циклам_Задание_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double x;
            do
            {
                Console.WriteLine("Введите значение x(Не меньше -1 и не больше 1");
                x = Convert.ToDouble(Console.ReadLine());
            } while (x>1 || x<-1);
            Console.Write("Введите значение n: ");
            double n = Convert.ToDouble(Console.ReadLine());

            double y=0;
            for(int i=1;i<=n;i++)
            {
                y += -Math.Pow(x,i) / i;
            }
            Console.WriteLine($"Сумма равна:{Math.Round(y,3)}");
        }
    }
}
