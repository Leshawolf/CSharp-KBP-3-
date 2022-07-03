using System;
using static System.Math;
using static System.Convert;
using static System.Console;

namespace Задание__3_Лаба__5
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
                arr[i] = rand.Next(-20, 20);
            }
            Write($"Массив до изменения: [");

            for (int i = 0; i < arr.Length; i++)
            {
                Write(arr[i] + " ");
            }
            WriteLine("]");
            int a, b;

            do
            {
                Write($"Диапазон [a,b] замены чисел начнётся с какой цифры?\nВведите значение:");
                a = ToInt32(ReadLine());
                Write($"Диапазон [a,b] замены чисел закончится какой цифрой(Не меньше прошлого значения))?\nВведите значение:");
                b = ToInt32(ReadLine());
            } while (a > b);

            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) >= a)
                {
                    if (Math.Abs(arr[i]) <= b)
                    {
                        arr[i] = 0;
                    }
                }
            }

            int flag = 0;
            int n = arr.Length-1;
            while (flag != n)
            {
                for (int i = 0; i < n; i++)
                {
                    if (i == n)
                    {
                        if (arr[i] == 0)
                        {
                            continue;
                        }
                    }
                        if(arr[i]==0)
                        {
                            int z = arr[i + 1];
                            arr[i + 1] = arr[i];
                            arr[i] = z;
                        }
                }
                flag++;
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
