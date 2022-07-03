using System;

namespace Практос_про_циклы
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вариает 5\n Задание 1");
            int x = -10;
            int sum = 0;
            do
            {
                if ((x%2)==0)
                {
                    sum += x;
                }
                x--;
            } while (x > -99);
            Console.WriteLine($"Ответ: {sum}");
        }
    }
}
