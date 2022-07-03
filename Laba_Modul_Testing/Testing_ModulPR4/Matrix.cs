using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_ModulPR4
{
    public class Matrix
    {
        public int n = 0,
            m = 0,
            chetn_digit = 0,
            min = int.MaxValue,
            max=int.MinValue,
            ind = 0,
            kol=0;
        public int[,] arr;
        public int[] sum;

        public Matrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            arr = new int[n, m];
            sum = new int[n];
        }
        public void Zapolnenie()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Random rand = new Random();
                    arr[i, j] = rand.Next(1, 100);
                }
            }
        }
        public void Show()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($" {arr[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        public int Nechetn()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sum[i] += arr[i, j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(sum[i] + " ");
                if (sum[i] <= min)
                {
                    ind = i;
                    min = sum[i];
                }
            }
            for (int i = 0; i < m; i++)
            {
                if(arr[i,ind]%2!=0)
                {
                    kol++;
                }
            }
            return kol;
        }
        public int ChetMax()
        {
            for (int i = 0; i < m; i++)
            {
                if (arr[ind, i] % 2 == 0)
                {
                    chetn_digit++;
                }
            }
            return chetn_digit;
        }
        public int SrednMax()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sum[i] += arr[i, j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(sum[i] + " ");
                if (sum[i] >= max)
                {
                    ind = i;
                    max = sum[i];
                }
            }
            var sredn = max / m;
            return sredn;
        }
        public int SumFull()
        {
            var sumfull = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sumfull += arr[i, j];
                }
            }
            return sumfull;
        }
        public int Minsum()
        {
            var min = 99999;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    sum[i] += arr[i, j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(sum[i] + " ");
                if (sum[i] <= min)
                {
                    min = sum[i];
                }
            }
            return min;
        }
    }
}