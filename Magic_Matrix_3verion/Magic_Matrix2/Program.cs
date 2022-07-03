using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            while (n % 4 != 0)
            {
                Console.Write("Введите n: ");
                n = Convert.ToInt32(Console.ReadLine());
            }

            int[,] arr = new int[n, n];
            bool flag = true;
            int res = n / 2;
            for (int i = 0; i < n; i++)
            {
                int k = 1;
                int o = n;
                for (int j = 0; j < n; j++)
                {
                    if (i == res)
                    {
                        flag = false;
                    }

                    if (flag == true)
                    {
                        if (i % 2 == 0)
                        {
                            arr[i, j] = k;
                            k++;
                            Console.Write($"{arr[i, j],7}");

                        }
                        else
                        {
                            arr[i, j] = o;
                            Console.Write($"{arr[i, j],7}");
                            o--;
                        }
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            arr[i, j] = o;
                            Console.Write($"{arr[i, j],7}");
                            o--;
                        }
                        else
                        {
                            arr[i, j] = k;
                            k++; 
                            Console.Write($"{arr[i, j],7}");

                        }
                    }

                }
                Console.WriteLine();
            }
                Console.WriteLine();
            int t = n;
            int l = 1;
            int[] arr2 = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    arr2[i] = 0;
                }
                else
                {
                    arr2[i] = t * l;
                    l++;
                }
            }

            int[,] arr3 = new int[n, n];
            bool flag2 = true;
            for (int i = 0; i < n; i++)
            {
                int v = n - 1;
                for (int j = 0; j < n; j++)
                {
                    if (i == res)
                    {
                        flag2 = false;
                    }

                    if (flag2 == true)
                    {
                        if (i % 2 == 0)
                        {
                            arr3[j, i] = arr2[j];
                        }
                        else
                        {
                            arr3[j, i] = arr2[v];
                            v--;
                        }
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            arr3[j, i] = arr2[v];
                            v--;
                        }
                        else
                        {
                            arr3[j, i] = arr2[j];
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{arr3[i, j],7}");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            int[,] arr4 = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr4[i, j] = arr[i, j] + arr3[i, j];
                    Console.Write($"{arr4[i, j],7}");
                }
                Console.WriteLine();
            }


            double sum = (Math.Pow(n, 3) + n) / 2;


            Console.WriteLine("Суммма: " + sum);
        }
    }
}

