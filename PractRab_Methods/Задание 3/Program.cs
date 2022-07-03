using System;

namespace Задание_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите x: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите y: ");
            int y = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите z: ");
            int z = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите f: ");
            int f = Convert.ToInt32(Console.ReadLine());
            int nok1 = Nok(x, y);
            int nok2 = Nok(z, f);
            int nok3 = Nok(nok1, nok2);
            Console.WriteLine($"Минимальное НОК: {nok3}");
        }
        static int Nok(int n,int m)
        {
            int nok=0;
            for (int i = 0; i < (n * m + 1); i++)
            {
                if (i % m == 0 && i % n == 0)
                {
                    nok = i;
                }
            }
            return nok;
        }
    }
}
