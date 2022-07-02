using System;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists("E:\\Проекты Visual Stidio\\File"))
            {
                Directory.CreateDirectory("E:\\Проекты Visual Stidio\\File");
            }
              //  Path.Combine()
            //  DirectoryInfo
            Directory.CreateDirectory("E:\\Проекты Visual Stidio\\File\\K1");
            Directory.CreateDirectory("E:\\Проекты Visual Stidio\\File\\K2");
            StreamWriter first_file = new StreamWriter("E:\\Проекты Visual Stidio\\File\\K1\\t1.txt");
            first_file.Write("Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов");
            first_file.Close();
            first_file = new StreamWriter("E:\\Проекты Visual Stidio\\File\\K1\\t2.txt");
            first_file.Write("Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс");
            first_file.Close();
            first_file = new StreamWriter("E:\\Проекты Visual Stidio\\File\\K2\\t3.txt");
            StreamReader second_file = new StreamReader("E:\\Проекты Visual Stidio\\File\\K1\\t1.txt");
            first_file.WriteLine(second_file.ReadToEnd());
            second_file.Close();
            second_file = new StreamReader("E:\\Проекты Visual Stidio\\File\\K1\\t2.txt");
            first_file.WriteLine(second_file.ReadToEnd());
            second_file.Close();
            first_file.Close();
            if (!File.Exists("E:\\Проекты Visual Stidio\\File\\K2\\t2.txt"))
            {
                File.Copy("E:\\Проекты Visual Stidio\\File\\K1\\t1.txt", "E:\\Проекты Visual Stidio\\File\\K2\\t1.txt");

            }
            else 
            {
                File.Delete("E:\\Проекты Visual Stidio\\File\\K2\\t1.txt");
                File.Copy("E:\\Проекты Visual Stidio\\File\\K1\\t1.txt", "E:\\Проекты Visual Stidio\\File\\K2\\t1.txt");
            }
            if (!Directory.Exists("E:\\Проекты Visual Stidio\\File\\ALL"))
            {
                Directory.Move("E:\\Проекты Visual Stidio\\File\\K2", "E:\\Проекты Visual Stidio\\File\\ALL");
            }
            else
            {
                Directory.Delete("E:\\Проекты Visual Stidio\\File\\ALL",true);
                Directory.Move("E:\\Проекты Visual Stidio\\File\\K2", "E:\\Проекты Visual Stidio\\File\\ALL");
            }
            Directory.Delete("E:\\Проекты Visual Stidio\\File\\K1", true);
            DirectoryInfo dop = new DirectoryInfo("E:\\Проекты Visual Stidio\\File\\ALL");
            FileInfo[] dopf = dop.GetFiles();
            foreach (FileInfo fi in dopf)
            {
                if (fi.Exists)
                {
                    Console.WriteLine($"Имя файла: {fi.Name}");
                    Console.WriteLine($"Время создания: {fi.CreationTime}");
                    Console.WriteLine($"Размер: {fi.Length}" );
                }
            }
        }
        //E:\\Проекты Visual Stidio\\File\\
    }
}