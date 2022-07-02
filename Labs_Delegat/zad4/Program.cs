using System;
namespace zad4;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Задание 4\nУсловие:\nРеализовать собственное событие (имитация) нажатие клавиш мыши или клавиатуры.\n" +
            "Разработать событием на основе стандартного события и собственно разработанного.\n" +
            "Типы событий выбирают в соответствии с вариантом.\n" +
            "Задание по варианту: Нажатие клавиши Enter");
        Key k = new Key();
   //     Console.ReadKey();
            k.Keys += Msg;

        while (true)
        {
            k.Push();
      //      Console.ReadKey();
        }
    }
    static void Msg(string s)
    {
        //   Console.ForegroundColor = ConsoleColor.Red;
     
        
            Console.WriteLine(new string('=', 50));
            Console.WriteLine(s);
        
     //   Console.ForegroundColor = ConsoleColor.White;
    }
}