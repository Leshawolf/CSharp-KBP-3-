using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegVr_KL;

namespace MSTest
{
    [TestClass]
    public class UnitTest1
    {
        int[,] matrix;

        [TestInitialize]
        public void TestMethod1()
        {
            matrix = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
        }

        [TestMethod]
        public void IsMatrixExists_returntrue()
        {
            MyMatrix obj = new MyMatrix(matrix);
            Assert.IsTrue(obj.IsMatrixExists());
        }

        [TestMethod]
        public void FindMinInRow1_return0()
        {
            MyMatrix obj = new MyMatrix(matrix);
            int expected = 4;
            int actual = obj.FindMinInRow(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindMaxInRow1_return1()
        {
            MyMatrix obj = new MyMatrix(matrix);
            int expected = 6;
            int actual = obj.FindMaxInRow(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ChangeNotMainDiagonal_returntrue()
        {
            MyMatrix obj = new MyMatrix(matrix);
            Assert.IsTrue(obj.ChangeNotMainDiagonal());
        }

        [TestMethod]
        public void FindAverageInRow1_return5()
        {
            MyMatrix obj = new MyMatrix(matrix);
            int expected = 5;
            int actual = obj.FindAverageInRow(1);
            Assert.AreEqual(expected, actual);
        }
    }
}