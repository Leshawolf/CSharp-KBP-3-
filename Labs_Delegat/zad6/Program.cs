using System;
namespace zad6;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"\n\nЗадание 6\n");
        Console.WriteLine($"Пример №1\n32 + 23 = {Calculator.Add(32, 23)}\n");
        Console.WriteLine($"Пример №2\n12 - 7 = {Calculator.Subtract(12, 7)}\n");
        Console.WriteLine($"Пример №3\n10 * 10 = {Calculator.Multiply(10, 10)}\n");
        Console.WriteLine($"Пример №4\n5 / 5 = {Calculator.Divide(5, 5)}");

        deleg d = (double a, double b) => a + b;
        Console.WriteLine(d(5, 5)+"\n");
        d = (double a, double b) => a * b;
        Console.WriteLine(d(5, 5));
    }

    delegate double deleg(double a, double b);
}