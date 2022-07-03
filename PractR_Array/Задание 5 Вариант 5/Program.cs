using static System.Math;
using static System.Convert;
using static System.Console;
using System;
namespace Задание_5_Вариант_5
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
            Write("Массив до изменения: [");
            for (int i = 0; i < arr.Length; i++)
            {
                Write($"{arr[i]} ");
            }
            WriteLine("]");
            Write("Введите число, от которого будут начинаться: ");
            int a = ToInt32(ReadLine());
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i]>=a)
                {
                    
                }
            }

            Write("Массив после изменения: [");
            for (int i = 0; i < arr.Length; i++)
            {
                Write($"{arr[i]} ");
            }
            Write("]");
        }
    }
    }
}
