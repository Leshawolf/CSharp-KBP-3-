using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing_ModulPR4;

namespace MatrixTest
{
    [TestClass]
    public class UnitTest1
    {
        int[,] arr;
        int max;
        Matrix matrix = new Matrix(4, 5);
        
        [TestInitialize]
        public void SetUp()
        {
            arr = new int[4, 5]
            {
                    {3,63,4,3,5},
                    {3,63,4,4,3},
                    {3,63,4,3,3},
                    {3,63,4,3,2},
            };

        }
        //[TestMethod]
        //public void SumMaxTest()
        //{
        //    matrix.arr = arr;
        //    int maxExp = 78;
        //    max = matrix.Maxsum();
        //    Assert.AreEqual(maxExp, max);
        //}
        [TestMethod]
        public void Nechetn() 
        {
            matrix.arr = arr;
            int ind = 3;
            max = matrix.Nechetn();
            Assert.AreEqual(ind, max);
        }
        [TestMethod]
        public void SrednTest()
        {
            matrix.arr = arr;
            int sredn = 15;
            max = matrix.SrednMax();
            Assert.AreEqual(sredn, max);
        }
        [TestMethod]
        public void SumFullTest()
        {
            matrix.arr = arr;
            int sumfull = 306;
            max = matrix.SumFull();
            Assert.AreEqual(sumfull, max);
        }
        [TestMethod]
        public void MinSumTest()
        {
            matrix.arr = arr;
            int minsum = 75;
            max = matrix.Minsum();
            Assert.AreEqual(minsum, max);
        }
    }
}