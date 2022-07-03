using System;
using static System.Math;
using static System.Convert;
using static System.Console;
namespace Задание__2_Лаба__5
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            int ind1=0;
            int[] arr = new int[] {2,4,-2,5,3,-2,3,-6 };
            for (int i = arr.Length-1; i >= 0; i--)
            {
                if (arr[i] > 0)
                {
                    ind1 = i;
                    break;
                }
            }
            for(int i=0;i<=ind1;i++)
            {

                    sum += arr[i];
            }
            Write($"Сумма всех чисел до отрицательного: {sum}\n");
        }
    }
}
