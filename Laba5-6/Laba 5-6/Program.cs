using System;
using static System.Math;
using static System.Convert;
using static System.Console;

namespace Laba_5_6
{
    class Program
    {
        static void Main(string[] args)
        {
            int ind=0;
            int[] array = new int[] {1,2,3,5,62,2,1,3,5};
            int max=array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if(max<array[i])
                {
                    ind = i;
                    max = array[i];
                }
            }
            Write($"Максимальное значение в массиве: {max}\nМаксимальное значение, находиться под индексом: {ind}\n");
        }
    }
}
