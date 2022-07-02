using System;
using System.Text;
using System.IO;
namespace TestApplicationForStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader fileIn = new StreamReader("E:\\Проекты Visual Stidio\\File\\File\\cities.txt");
            int strLenght = 0;
            var ind1 = 0;
            var ind = 0;
            do
            {
                ind++;
                int i = fileIn.ReadLine().Length;
                if (strLenght < i)
                {
                    ind1 = ind;
                    strLenght = i;
                }

            } while (!fileIn.EndOfStream);

            Console.WriteLine($"Строка № {ind1}");
            Console.WriteLine($"Длина строки: {strLenght}");
            fileIn.Close();
        }
    }
}