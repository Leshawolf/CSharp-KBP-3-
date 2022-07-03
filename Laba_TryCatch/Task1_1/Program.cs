using System;

namespace Task1_2
{
    class Program
    {
        static void main(string[] args)
        {
            try
            {
                int N, K;
                Console.Write("Введите N: ");
                N = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите K: ");
                K = Convert.ToInt32(Console.ReadLine());
                if (true)
                {
                    int[] arr = new int[N];
                    for (int i = 0; i < arr.Length; i++)
                    {
                        Random rnd = new Random();
                        arr[i] = rnd.Next(1, 200);
                    }
                    arr[K++] = 0;
                }
                else
                {
                    throw new Exception("Ваш элемент N, должен быть больше K");
                }
            }
            catch(ArgumentException e)
            {
                throw new ArgumentException("Вы передали неккоректное значение");
            }
            catch(IndexOutOfRangeException e)
            {
                throw new IndexOutOfRangeException("Вы вышли за границы массива");
            }
            catch(NullReferenceException e)
            {
                throw new NullReferenceException("Вы выполняете обращения к объекту, который равен null");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                Console.WriteLine($"Метод: {ex.TargetSite}");
                Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            }
        }


    }
}
