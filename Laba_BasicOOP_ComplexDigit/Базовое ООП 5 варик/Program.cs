using System;

namespace Базовое_ООП_5_варик
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Введите мнимую часть числа: ");
            //double actual_part=Convert.ToDouble(Console.ReadLine());
            //Console.Write("Введите действительную часть числа: ");
            //double imaginary_part = Convert.ToDouble(Console.ReadLine());
            //Console.Write("Введите аргумент: ");
            //double argument = Convert.ToDouble(Console.ReadLine());
            //Console.Write("Введите модуль: ");
            //double modul = Convert.ToDouble(Console.ReadLine());
            //var a = Complex_digital.Complex_Create(modul, argument);
            //Console.WriteLine($"{a}");
            Complex_digital c = Complex_digital.Complex_Create(3, 4);
            Complex_digital d = Complex_digital.Triganamet(3, 4);
            Console.WriteLine(c.Argument);
            Console.WriteLine(c.Modul);
            Console.WriteLine(c.Real);
            Console.WriteLine(c.Image);
        }
    }
}
