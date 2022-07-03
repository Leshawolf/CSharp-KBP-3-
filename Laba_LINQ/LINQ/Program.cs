using System;
using System.Linq;
using System.Collections.Generic;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите n: ");
            int n = Convert.ToInt32(Console.ReadLine());

            double[] arr = new double[n];
            Console.WriteLine("Заполнение массива: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"[{i}] ");
                arr[i] = Convert.ToDouble(Console.ReadLine());

            }
            Show(arr);
            Console.WriteLine("\nМаксимальное значение: "+ arr.Max());
            var sum = arr.Reverse().SkipWhile(x => x < 0).Reverse().Sum();
            Console.WriteLine("Сумма: " + sum);
            Console.WriteLine("Введите диапазон от а до б: ");
            Console.Write("Введите а: ");
            double a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите b: ");
            double b = Convert.ToInt32(Console.ReadLine());
            double[] arr1 = arr.Where(x => (Math.Abs(x) < a || Math.Abs(x) > b)).ToArray();
            Show(arr1);


            Console.ReadKey();
            n = Convert.ToInt32(Console.ReadLine());
        }
        public static void Show(double[] arr)
        {
            Console.WriteLine("Массив: ");
            Console.Write("[ ");
            foreach (var item in arr)
            {
                Console.Write(item+" ");
            }
            Console.Write(" ]");
        }
    }

    
}
