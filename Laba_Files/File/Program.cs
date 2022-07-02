using System;
using System.Text;
using System.IO;
namespace TestApplicationForStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Сколько вы хотите записать цифр в файл? :");
        //    int a = Convert.ToInt32(Console.ReadLine());
          //  int b;
            var path = "E:\\Проекты Visual Stidio\\File\\File\\t1";
            int[] b = new int[10] { 1,2,3,4,5,6,7,8,9,10};

            using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                bw.Write("hello");
                Console.WriteLine("hello");
                for (int i = 0; i < 10; i++)
                {
                 //   b = Convert.ToInt32(Console.ReadLine());
                //    if (b % 2 == 0)
                    {
                        bw.Write(b[i]);
                        Console.WriteLine(b[i]);
                    }

                }
                //    bw.Close();
            }
            int autoSaveTime=0;
            Console.WriteLine("...................................");
            Console.WriteLine("Auto save time set to: ");
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                Console.WriteLine(reader.ReadString());
                while (reader.PeekChar() != -1)
                {
                    Console.WriteLine( reader.ReadInt32());
                }
                
            }

 
        }


        /*            Console.WriteLine("..................................");
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
                    Console.WriteLine("..................................");
                */
    }
    }