using System;

using static System.Math;
using static System.Convert;
using static System.Console;

namespace Задание__1_Лаба__6
{
    class Program
    {
        static void Main(string[] args)
        {

            Write("\tЗадание №1 \nВведите размерность массива: ");
            int x = ToInt32(ReadLine());
            Random rand = new();
            int[,] arr = new int[x, x];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    arr[i, j] = rand.Next(-5, 20);

                    Console.Write($"{arr[i, j]}\t");
                }
                Console.WriteLine(" ");
            }
            for (int i = 0; i < x; i++)
            {
                int sum = 0;
                bool f = true;

                for (int j = 0; j < x; j++)
                {
                    sum += arr[j, i];
                    if (arr[j, i] < 0)
                    {
                        f = false;
                    }
                }

                if (f)
                {
                    Console.WriteLine($"Cумма элементов столбца = [{i}]:  {sum}");
                }

            }
        }
    }
}
