using System;

namespace Задание_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размерность массивов: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr1 = new int[n];
            int[] arr2 = new int[n];
            int[] arr3 = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                arr1[i] = rnd.Next(-5,10);
                arr2[i] = rnd.Next(-5, 10);
                arr3[i] = rnd.Next(-5, 10);
            }
            Console.Write("X: ");
            Show(arr1);
            Console.Write("Y: ");
            Show(arr2);
            Console.Write("Z: ");
            Show(arr3);
            int ar1 = Change(arr1, n);
            int ar2= Change(arr2, n);
            int ar3 = Change(arr3, n);
            if ((ar1>ar2)&&(ar1>ar3))
            {
                Console.WriteLine("X");
                RaschetX_and_Z(arr1, arr1.Length);
                Show(arr1);
            }
            if ((ar2 > ar1) && (ar2 > ar3))
            {
                Console.WriteLine("Z");
                RaschetX_and_Z(arr2, arr2.Length);
                Show(arr2);
            }
            if ((ar3 > ar2) && (ar3 > ar1))
            {
                Console.WriteLine("Y"); 
                Raschet_Y(arr3, arr3.Length);
                Show(arr3);
            }

        }
        static int Change(int[] arr, int n)
        {
            int polozhit=0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i]<=0)
                {
                    polozhit++;
                }
            }
            return polozhit;
        }
        static void RaschetX_and_Z(int[] arr,int n)
        {
            for (int i = 0; i < n; i++)
            {
                if(arr[i]>=0)
                {
                    arr[i] =(int) Math.Pow(arr[i], 3);
                }
            }
           
        }
        static void Raschet_Y(int[] arr,int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (arr[i] >= 0)
                {
                    arr[i] = 1/ arr[i];
                }
            }
        }
        static void Show(int[] a)
        {
            foreach (var x in a)
                Console.Write($"{x,6:f1}");
            Console.WriteLine();
        }
        static void Show(double[] a)
        {
            foreach(var x in a)
                Console.Write($"{x,6:f1}");
            Console.WriteLine();
        }
    }
}
