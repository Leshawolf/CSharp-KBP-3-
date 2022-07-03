using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using RegVr_KL;

namespace pr4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            MyMatrix obj = new MyMatrix(matrix);
            Console.WriteLine(obj.FindAverageInRow(1));
        }
    }
}
