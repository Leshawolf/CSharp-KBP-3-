using System;
namespace Obobschenie;
class Program
{
    static void Main(string[] args)
    {
        StackFixed<int> p = new StackFixed<int>(5);
        int buf;
        do
        {
            buf = Convert.ToInt32(Console.ReadLine());
            if (buf != 0)
            {
                p.Push(buf);
            }
        } while (buf != 0);
        while (p.Size()>0)
        {
            Console.Write(p.Pop());
        }
    }
}

