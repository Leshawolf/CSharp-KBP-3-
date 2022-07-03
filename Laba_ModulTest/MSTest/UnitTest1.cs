using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using MSTest;
using ModulTest;

namespace MSTest
{
    [TestClass]
    public class UnitTest1
    {
        double[,] arr;
        Matrix p;
        [TestInitialize]
        public void SetUp()
        {
            p = new Matrix(3);
            arr = new double[3, 3]
            {
                {2,3,6},
                {7,2,1},
                {9,3,8}
            };
        }

        [TestMethod]
        public void Max()
        {

            double[] expected = { 6, 7, 9 };
            double[] actuale = p.Max(arr);
            Assert.AreEqual(expected.SequenceEqual(actuale), true);
        }
        [TestMethod]
        public void Sum()
        {

            double expected = 12;
            double actuale = p.Sum(arr);
            Assert.AreEqual(actuale, expected);
        }
        [TestMethod]
        public void SumFull()
        {

            double expected = 41;
            double actuale = p.SumFull(arr);
            Assert.AreEqual(actuale, expected);
        }
        [TestMethod]
        public void Min()
        {

            double[] expected = { 2, 1, 3 };
            double[] actuale = p.Min(arr);
            Assert.AreEqual(expected.SequenceEqual(actuale), true);
        }
        [TestMethod]
        public void Max_Chetn()
        {

            double expected = 4;
            double actuale = p.Max_Chetn(arr);
            Assert.AreEqual(actuale, expected);
        }
    }
}