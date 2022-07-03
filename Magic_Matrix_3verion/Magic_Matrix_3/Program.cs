﻿using System;

namespace lab2
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Введите n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            while (n % 2 != 0 || n % 4 == 0)
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
                        if (i % 2 != 0)
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
                        if (i % 2 != 0)
                        {
                            arr3[j, i] = arr2[j];
                        }
                        else
                        {
                            arr3[j, i] = arr2[v];
                            v--;
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
            Console.WriteLine();
            Console.WriteLine($"{"Сумма",10}: {sum}");


            int xz = n - 2;
            for (int i = 1; i < res; i++)
            {
                int temp = arr4[0, i];
                arr4[0, i] = arr4[0, xz];
                arr4[0, xz] = temp;
                xz--;
            }

            int xz2 = n - 2;
            for (int i = 1; i < res; i++)
            {
                int temp = arr4[i, 0];
                arr4[i, 0] = arr4[xz2, 0];
                arr4[xz2, 0] = temp;
                xz2--;
            }


            for (int i = 2; i < n - 2; i++)
            {
                int temp = arr4[1, i];
                arr4[1, i] = arr4[1, i];
            }



            int temp2 = arr4[1, res];
            arr4[1, res] = arr4[1, res - 1];
            arr4[1, res - 1] = temp2;

            int temp3 = arr4[res, 1];
            arr4[res, 1] = arr4[res - 1, 1];
            arr4[res - 1, 1] = temp3;

            int temp4 = arr4[n - 1, res];
            arr4[n - 1, res] = arr4[n - 1, res - 1];
            arr4[n - 1, res - 1] = temp4;

            int temp5 = arr4[res, n - 1];
            arr4[res, n - 1] = arr4[res - 1, n - 1];
            arr4[res - 1, n - 1] = temp5;

            int temp6 = arr4[res - 1, n - 1];
            arr4[res - 1, n - 1] = arr4[res - 1, 0];
            arr4[res - 1, 0] = temp6;

            int temp7 = arr4[0, res - 1];
            arr4[0, res - 1] = arr4[n - 1, res - 1];
            arr4[n - 1, res - 1] = temp7;


            System.Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{arr4[i, j],7}");
                }
                Console.WriteLine();
            }
        }
    }
}
