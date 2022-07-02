using System;
namespace zad1;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Задание 1\n");

        Console.WriteLine("Введите х начальное: ");
        double xnach = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите х конечное: ");
        double xkon = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите шаг: ");
        double shag = Convert.ToDouble(Console.ReadLine());
        Zadanie1 sin = aSin;
        Zadanie2 cos =aCos;
        Console.WriteLine("aCos(x)  \taSin(x)");
        for (; xnach < xkon; xnach += shag)
        {
            Console.WriteLine($"{cos(xnach):f2}  \t{sin(xnach):f2}");
        }
    }
    static double aSin(double x) { return Math.Asin(x); }
    static double aCos(double x) { return Math.Acos(x); }
}
delegate double Zadanie1(double x);
delegate double Zadanie2(double x);
