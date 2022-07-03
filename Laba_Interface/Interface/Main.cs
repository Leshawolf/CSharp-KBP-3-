using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[5] { 5, 0, 3, 4, 0 };
            int sum = 0;
            int k1 = -1;
            int k2 = -1;
            for (int i = 0; i < arr.Length; i++)
            {

                if (arr[i] == 0)
                {
                    k1 = i;
                    break;
                }
            }
            if (k1 == -1)
            {
                Console.WriteLine("\nНет нулей");
            }
            else
            {
                for (int k = k1 + 1; k < arr.Length; k++)
                {
                    sum += arr[k];
                    if (arr[k] == 0)
                    {
                        k2 = k;
                        break;
                    }

                }
            }
            if (k2 == -1)
            {
                Console.WriteLine("\nНет второго нуля в массиве");
            }
            else
            {
                Console.WriteLine("\nCумма элементов: " + sum);
            }
        }
    }
}