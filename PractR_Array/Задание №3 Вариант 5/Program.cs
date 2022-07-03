using System;
using static System.Math;
using static System.Convert;
using static System.Console;
namespace Задание__3_Вариант_5
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
                arr[i] = ToInt32(ReadLine());
            }
            Write($"Массив до изменения: [");
            for (int i = 0; i < arr.Length; i++)
            {
                Write(arr[i] + " ");
            }
            WriteLine("]");
            Array.Reverse(arr);
            Write($"Массив после изменения: [");
            for (int i = 0; i < arr.Length; i++)
            {
                Write(arr[i] + " ");
            }
            WriteLine("]");
        }
    }
}
