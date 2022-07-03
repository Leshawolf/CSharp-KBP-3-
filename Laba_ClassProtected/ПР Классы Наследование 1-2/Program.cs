using System;
using System.Collections.Generic;
using System.Linq;

namespace ПР_Классы_Наследование_1_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Задание №1 Пр часть 1");
            Y0 test = new Y0(3,3,3);
            Console.WriteLine(test.Run());
            Console.WriteLine("Задание №2 Пр часть 1");
            Circle a = new Circle(1, 23, 32, 123);
            a.S();
            a.Show();
            Cylinder b = new Cylinder(23,10,23,32,1);
            b.S();
            b.V();
            b.Show();
            Console.WriteLine("Задание 1 ПР часть 2");
            Money money1 = new Money(3, 25);
            Money money2 = new Money(1, 90);
            var aa = money1.Slog(money2);
            Pair pair1 = new Pair(2, 3);
            Pair pair2 = new Pair(5, 2);
            Console.WriteLine( pair1.Slog(pair2));
            Money money3 = new Money(20, 38);
            Money money4 = money1 - money2;
            Console.WriteLine(money1 + money2);
            Console.WriteLine($"Первое: {money1}   Второе: {money2} \nТрутье: {money3}  Четвёртое: {money4}");
        }
        
    }
}