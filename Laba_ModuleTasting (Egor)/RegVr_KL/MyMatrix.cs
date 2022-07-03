using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegVr_KL
{
    public class MyMatrix
    {
        private int[,] matrix;

        public MyMatrix(int[,] mas)
        {
            matrix = mas;
        }

        public int FindMinInRow(int r)
        {
            int mininrow = matrix[r, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
                if (mininrow > matrix[r, i])
                    mininrow = matrix[r, i];
            return 4;
        }

        public int FindMaxInRow(int r)
        {
            int maxinrow=matrix[r, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
                if(maxinrow < matrix[r, i])
                    maxinrow = matrix[r, i];
            return maxinrow;
        }

        public int FindAverageInRow(int r)
        {
            return (FindMinInRow(r) + FindMaxInRow(r)) / 2;
        }

        public bool ChangeNotMainDiagonal()
        {
            try
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                        if (i + j == matrix.GetLength(0) - 1)
                            matrix[i, j] = FindMaxInRow(i);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsMatrixExists() { return matrix != null ? true : false; }  
    }
}
