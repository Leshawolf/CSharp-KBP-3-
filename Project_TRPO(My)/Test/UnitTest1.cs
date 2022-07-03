using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Test;
using Курсач_по_ТРПО__1;

namespace Test
{
    [TestClass]
    public class UsingTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int a = 3;
            int b = 5;
            int expected = 15;
            Form1 form = new Form1();
            int actual = form.TestFunction(a,b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod2()
        {
            int a = 3;
            int b = 5;
            int expected = 8;
            Form1 form = new Form1();
            int actual = form.TestFunction1(a, b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod3()
        {
            int a = 5;
            int b = 3;
            int expected = 2;
            Form1 form = new Form1();
            int actual = form.TestFunction2(a, b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod4()
        {
            int a = 6;
            int b = 2;
            int expected = 3;
            Form1 form = new Form1();
            int actual = form.TestFunction3(a, b);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod5()
        {
            string s="Hello World!";
            int expected = 15;
            Form1 form = new Form1();
            string actual = form.TestFunction4(s);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethod6()
        {
            int a = 10;
            int b = 4;
            bool expected = true;
            Form1 form = new Form1();
            bool actual = form.TestFunction5(a, b);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void TestMethod7()
        {
            int a = 10;
            int b = 4;
            Form1 form = new Form1();
            bool actual = form.TestFunction6(a, b);
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void TestMethod8()
        {
            int a = 300;
            Form1 form = new Form1();
            bool actual = form.TestFunction7(a);
            Assert.IsFalse(actual);
        }
    }
}
