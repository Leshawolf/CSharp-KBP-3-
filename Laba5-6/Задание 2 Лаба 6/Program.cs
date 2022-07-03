using System;
namespace Задание_2_Лаба_6
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 6;
            int[,] arr = new int[n, n];
            Random rand = new Random();
            for (int i = 0; i != n; i++)
            {
                for (int j = 0; j != n; j++)
                {
                    arr[i, j] = rand.Next(-5, 5);

                    Console.Write($"{arr[i, j],6}");
                }
                Console.WriteLine();
            }

            int min = int.MaxValue;
            for (int k = 1; k != n; k++)
            {
                int sum1 = 0;
                int sum2 = 0;
                for (int i = n - 1, j = 0; i >= k; i--, j++)
                {
                    sum1 += Math.Abs(arr[i - k, j]);
                    sum2 += Math.Abs(arr[i, j + k]);
                }
                min = Math.Min(min, Math.Min(sum1, sum2));
            }
            Console.WriteLine("\fMin: " + min);

        }
    }
}
