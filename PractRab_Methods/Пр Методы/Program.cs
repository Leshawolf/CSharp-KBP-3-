using System;

namespace Пр_Методы
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] x1 = { 1.0, 5.0, 3.0 };
            double[] y1 = { 1.0, 2.0, 3.0 };

            double[] x2 = { 2.0, 4.0, 6.0 };
            double[] y2 = { 5.0, 3.0, 4.0 };
            double S1 = Arr(x1, y1); 
            double S2 = Arr(x2, y2);
            Console.WriteLine($"Площадь первого: {S1}\nПлощадь второго: {S2}");
        }

        static double Arr(double[] x, double[] y)
        {
            return 0.5 * Math.Abs((x[1] - x[0]) * (y[2] - y[0]) - (x[2] - x[0]) * (y[1] - y[0]));
        }
    }
}
