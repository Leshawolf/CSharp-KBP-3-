using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathTaskClassLibraryTest;
using Курсач_по_ТРПО__1;

namespace MathTaskClassLibraryTest
{
    [TestClass]
    public class ModelTestNum2
    {
        [TestMethod]
        public void TestMethod1()
        {
            int a = 3;
            int b = 5;
            int expected = 15;


            Form1 g = new Form1();
            int test = g.TestFunction(a, b);
            Assert.AreEqual(expected, test);
        }
        [TestMethod]
        public void TestMethod2()
        {
            int a = 3;
            int b = 5;
            int expected = 8;


            Form1 g = new Form1();
            int test = g.TestFunction1(a, b);
            Assert.AreEqual(expected, test);
        }
        [TestMethod]
        public void TestMethod3()
        {
            int a = 3;
            int b = 5;
            int expected = -2;


            Form1 g = new Form1();
            int test = g.TestFunction2(a, b);
            Assert.AreEqual(expected, test);
        }
        [TestMethod]
        public void TestMethod4()
        {
            int a = 6;
            int b = 2;
            int expected = 3;


            Form1 g = new Form1();
            int test = g.TestFunction3(a, b);
            Assert.AreEqual(expected, test);
        }
        [TestMethod]
        public void TestMethod5()
        {
            string s = "Hello World!";
            Form1 g = new Form1();
            string sa = g.TestFunction4(s);
            Assert.AreEqual(s, sa);
        }
        [TestMethod]
        public void Signe()
        {
            string l = "pla";
            string p = "Qaz";
            bool expected = true;
            Form1 form = new Form1();
            bool res = form.SignIn(l, p);
            Assert.AreEqual(expected, res);
        }
    }
}
