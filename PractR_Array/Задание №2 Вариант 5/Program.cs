using System;
using static System.Math;
using static System.Convert;
using static System.Console;
namespace Задание__2_Вариант_5
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
            for (int i = 0; i < arr.Length; i++)
            {
                Write(arr[i] + " ");
            }
            WriteLine("]");
            int ind_max = 0,max=arr[0],min=arr[0],ind_min=0;
            for(int i=0;i<arr.Length;i++)
            {
                if(max<arr[i])
                {
                    max = arr[i];
                    ind_max = i;
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                    ind_min = i;
                }
            }
            int count=0;
            for(int i=ind_min++;i<ind_max;i++)
            {
                count++;
            }
            WriteLine($"Между максимальным и минимальным элементом в массиве {count} чисел");
        }
    }
}
