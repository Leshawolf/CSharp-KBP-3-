using System;

namespace Try_Catch_Final1and2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double a, b, c, S;
                Console.Write("Введите сторону a: ");
                a = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите сторону b: ");
                b = Convert.ToDouble(Console.ReadLine());

                Console.Write("Введите угол C: ");
                c = Convert.ToDouble(Console.ReadLine());

                S = 0.5 * a * b * Math.Sin(c);

                Console.Write($"Площадь равна: {S}" );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                Console.WriteLine($"Метод: {ex.TargetSite}");
                Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            }
        }
    }
}
