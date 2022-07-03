using System;
using static System.Convert;
using static System.Console;
using System.Linq;

namespace Задание_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //string text = Console.ReadLine();
            //string[] arr = text.Split(':');

            //int count = 0;

            //foreach (var item in arr)
            //{
            //    int count2 = 0;
            //    for (int i = 0; i < item.Length; i++)
            //    {
            //        count2++;
            //    }
            //    if (count2 % 2 != 0)
            //    {
            //        System.Console.WriteLine(item);
            //    }
            //    count++;
            //}
            //System.Console.WriteLine(count);
            ///Тык
            //string text = Console.ReadLine();
            //text = text.Remove(text.Length - 1);
            //string[] arr = text.Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //int min = 99999;
            //string word = "";
            //foreach (var item in arr)
            //{
            //    int count = item.Length;
            //    Console.WriteLine($"{item,10}  {item.Length}");
            //    //for (int i = 0; i < item.Length; i++)
            //    //{
            //    //    count++;
            //    //}
            //    if (item[item.Length - 1] == 'а' && count < min)
            //    {
            //        min = count;
            //        word = item;
            //    }
            //}
            //System.Console.WriteLine(word);
            ///////////Ещё тык
            string text = Console.ReadLine();
            text = text.Remove(text.Length - 1);
            string[] arr = text.Split(':');
            foreach (var item in arr)
            {
                if (item[item.Length - 1] != 'а')
                {
                    System.Console.Write(item + ":");
                }
            }

        }
    }
}