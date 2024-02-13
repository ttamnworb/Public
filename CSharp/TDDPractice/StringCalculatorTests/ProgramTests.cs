using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AddTest1()
        {
            // When the Add() receives an empty string zero is returned.
            Assert.AreEqual(0, Program.Add(string.Empty));
        }

        [TestMethod()]
        public void AddTest2()
        {
            // When the Add() receives a string containing a single number that number is returned.
            Assert.AreEqual(42, Program.Add("42"));
        }
        [TestMethod()]
        public void AddTest3()
        {
            // When the Add() receives a string containing two numbers their sum is returned.
            Assert.AreEqual(2, Program.Add("1,1"));
            Assert.AreEqual(4, Program.Add("2,2"));
            Assert.AreEqual(100, Program.Add("42,58")); 
        }

        [TestMethod()]
        public void AddTest4()
        {
            // When the Add() receives a string containing multiple numbers their sum is returned.
            Assert.AreEqual(5, Program.Add("1,1,1,1,1"));
            Assert.AreEqual(4, Program.Add("0,0,0,2,2"));
            Assert.AreEqual(300, Program.Add("42,58,100,100"));
        }
        [TestMethod()]
        public void AddTest5()
        {
            // When the Add() receives a string containing multiple numbers their sum is returned.
            Assert.AreEqual(5, Program.Add("1\n1,1,1\n1"));
            Assert.AreEqual(4, Program.Add("0\n0\n0,2,2"));
            Assert.AreEqual(300, Program.Add("42,58,100,100"));

            Assert.AreEqual(6, Program.Add("1,2\n3"));
            Assert.AreEqual(0, Program.Add("2,\n3"));
        }
        [TestMethod()]
        public void AddTest6()
        {
            // Allow the use of a custom delimiter
            Assert.AreEqual(45, Program.Add("//;\n0;1;2;3;4;5;6;7;8;9"));
            Assert.AreEqual(0, Program.Add("//;\t0;1;2;3;4;5;6;7;8;9"));   
        }

        [TestMethod()]
        public void AddTest7()
        {
            // Negative values will be rejected
            Assert.AreEqual(0, Program.Add("0,1,-2"));
            // Numbers greater than 1000 will be ignored.
            Assert.AreEqual(1000, Program.Add("0,1,999"));
            Assert.AreEqual(1001, Program.Add("0,1,1000"));
            Assert.AreEqual(1, Program.Add("0,1,1001"));
        }
    }
}