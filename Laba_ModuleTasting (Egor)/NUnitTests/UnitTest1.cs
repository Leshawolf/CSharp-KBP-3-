using NUnit.Framework;
using RegVr_KL;

namespace NUnitTests
{
    public class Tests
    {
        int[,] matrix;
              
        [SetUp]
        public void Setup()
        {
            matrix = new int[3, 3]
            {
                { 10, 20, -30 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
        }

        [Test]
        public void IsMatrixExists_returntrue()
        {
            MyMatrix obj = new MyMatrix(matrix);
            Assert.IsTrue(obj.IsMatrixExists());
        }
        [Test]
        public void FindMinInRow1_return0()
        {
            MyMatrix obj = new MyMatrix(matrix);
            int expected = 4;
            int actual = obj.FindMinInRow(1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void FindMaxInRow1_return1()
        {
            MyMatrix obj = new MyMatrix(matrix);
            int expected = 6;
            int actual = obj.FindMaxInRow(1);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ChangeNotMainDiagonal_returntrue()
        {
            MyMatrix obj = new MyMatrix(matrix);
            Assert.IsTrue(obj.ChangeNotMainDiagonal());
        }

        [Test]
        public void FindAverageInRow1_return5()
        {
            MyMatrix obj = new MyMatrix(matrix);
            int expected = 5;
            int actual = obj.FindAverageInRow(1);
            Assert.AreEqual(expected, actual);
        }
    }
}