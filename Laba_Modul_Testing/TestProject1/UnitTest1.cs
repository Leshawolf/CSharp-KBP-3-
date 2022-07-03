using NUnit.Framework;
using Testing_ModulPR4;

namespace TestProject1
{
    public class Tests
    {
        int[,] arr;
        int max;
        Matrix matrix = new Matrix(4, 5);

        [SetUp]
        public void SetUp()
        {
            arr = new int[4, 5]
            {
                    {3,-63,4,3,5},
                    {3,63,4,3,4},
                    {3,63,4,3,3},
                    {3,63,4,3,2},
            };

        }
        [Test]
        public void SumMaxTest()
        {
            matrix.arr = arr;
            int maxExp = 78;
            max = matrix.Maxsum();
            Assert.AreEqual(maxExp, max);
        }
        [Test]
        public void Chetn_Max()
        {
            matrix.arr = arr;
            int ind = 1;
            max = matrix.ChetMax();
            Assert.AreEqual(ind, max);
        }
        [Test]
        public void SrednTest()
        {
            matrix.arr = arr;
            int sredn = 15;
            max = matrix.SrednMax();
            Assert.AreEqual(sredn, max);
        }
        [Test]
        public void SumFullTest()
        {
            matrix.arr = arr;
            int sumfull = 306;
            max = matrix.SumFull();
            Assert.AreEqual(sumfull, max);
        }
        [Test]
        public void MinSumTest()
        {
            matrix.arr = arr;
            int minsum = 75;
            max = matrix.Minsum();
            Assert.AreEqual(minsum, max);
        }
    }
}