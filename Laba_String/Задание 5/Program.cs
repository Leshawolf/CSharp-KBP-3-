using System;
using static System.Convert;
using System.Linq;
using static System.Console;
using static System.Math;

namespace Задание_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целочисленное число: ");
            string Number = ReadLine();
            char[] arr= Number.ToCharArray();
            int b=0;
            int i;
            int sum = 0;
            //Console.WriteLine(arr);
            //foreach (var item in arr)
            //{

            //    Console.WriteLine((int)(item - '0'));
            //}

                for (i = 0; i < Number.Length; i++)
                {
                    Console.Write($"Arr{arr[i]} \t");
                    if (i % 2 != 0)
                    {
                        b = (int)(arr[i] - '0');
                        Console.WriteLine($"B {b}");
                        sum += b;
                    }
                }
            Console.WriteLine(sum);
        }
    }
}
   