using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModulTest
{
    public class Matrix
    {
        int n;
        double[,] arr;

        public Matrix(int n)
        {
            this.n = n;
            arr = new double[n, n];
        }

        public void Input()
        {
            Random r = new Random();
            int a = 0;
            double b = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    a = r.Next(-10, 10);
                    b = r.NextDouble();
                    arr[i, j] = a + b;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    System.Console.Write($"{arr[i, j],7:f2} | ");
                }
                System.Console.WriteLine();
            }
        }

        public double[] Max(double[,] arr)
        {
            double[] mass = new double[arr.GetLength(0)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                double max = arr[i, 0];
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                    }
                }
                mass[i] = max;
            }
            return mass;
        }
        public int Max_Chetn(double[,] arr)
        {
            int kol = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
               
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] %2==0)
                    {
                        kol++;
                    }
                }
            }

            return kol;
        }

        public double Sum(double[,] arr)
        {
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        sum += arr[i, j];
                    }
                }
            }
            return sum;
        }

        public double[,] Change_Max(double[,]arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                double max = arr[i, 0];
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                    }
                }
                arr[i, i] = max;
            }
            return arr;
        }
        public double SumFull(double[,] arr)
        {
            var sumfull = 0.0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sumfull += arr[i, j];
                }
            }
            return sumfull;
        }
        public double[] Min(double[,] arr)
        {
            double[] mass = new double[arr.GetLength(0)];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                double min = arr[i, 0];
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                    }
                }
                mass[i] = min;
            }
            return mass;
        }
    }
}
