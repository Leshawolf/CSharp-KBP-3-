using System;
using static System.Math;
using static System.Convert;
using static System.Console;

namespace Пр_массивы
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Введите размерность массива:");
            int ind = Convert.ToInt32(ReadLine());
            Random rand = new();
            int[] arr = new int[ind];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(10, 20);
            }
            Write($"Массив до изменения: [");
            for(int i=0;i<arr.Length;i++)
            {
                Write(arr[i] + " ");
            }
            WriteLine("]");
            for(int i=0;i<arr.Length;i++)
            {
                if(i%2==0)
                {
                    arr[i] = i / 2;
                }
            }
            Write($"Массив после изменения: [");
            for (int i = 0; i < arr.Length; i++)
            {
                Write(arr[i] + " ");
            }
            WriteLine("]");
        }
        }
    }
