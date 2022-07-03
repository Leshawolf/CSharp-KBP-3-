using static System.Math;
using static System.Convert;
using static System.Console;
using System;

namespace Задание__4_Вариант_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1,2,3,4,5,6,7,8,9};
            Write("Массив до изменения: [");
            for (int i = 0; i < arr.Length; i++)
            {
                Write($"{arr[i]} ");
            }
            WriteLine("]");
            Array.Reverse(arr);
            Write("Массив после изменения: [");
            for (int i = 0; i < arr.Length; i++)
            {
                Write($"{arr[i]} ");
            }
            Write("]");
        }
    }
}
