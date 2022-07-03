using System;

namespace Задание_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размерность массива: ");
            int n=Convert.ToInt32(Console.ReadLine());
            double[,] arr=new double[n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = Convert.ToDouble(Console.ReadLine());
                }
                Console.WriteLine("");
            }
            Console.WriteLine("Массив:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{arr[i,j],6}");

                }
                Console.WriteLine("");
            }

            Console.WriteLine("Ряды в которых все числа делятся на 3 без остатка: ");
            Array(arr, n);
        }
        static void Array(double[,] arr1,int n)
        {
            int flag = 0;
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    if(arr1[i,j]%3==0)
                    {
                        flag++;

                    }
                }
                if (flag == n)
                {
                    Console.WriteLine(i+1);
                }
                flag = 0;
            }
        }
    }
}
