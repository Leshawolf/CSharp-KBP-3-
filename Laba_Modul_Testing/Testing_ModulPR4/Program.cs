using System;
using System.Text;
using System.IO;
namespace Testing_ModulPR4
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix(5, 10);
            matrix.Zapolnenie();
            matrix.Show();
            matrix.Minsum();
            matrix.ChetMax();

        }
    }
}
