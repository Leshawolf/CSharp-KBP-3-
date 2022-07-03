using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание №2");
            string[] text = File.ReadAllText("text.txt").Split(' ');
            Queue<string> Upper = new Queue<string>();
            Queue<string> Lower = new Queue<string>();
            foreach (string ch in text)
            {
                if (ch.ToUpper()[0] == ch[0])
                {
                    Upper.Enqueue(ch);
                }
                else
                {
                    Lower.Enqueue(ch);
                }
            }
            while (Upper.Count > 0)
            {
                Console.Write(Upper.Dequeue() + " ");
            }
            while (Lower.Count > 0)
            {
                Console.Write(Lower.Dequeue() + " ");
            }
        }

    }
}