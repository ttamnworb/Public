using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FizzBuzz.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void FizzBuzzTest1()
        {
            Assert.AreEqual("1", Program.FizzBuzz(1));
            Assert.AreEqual("2", Program.FizzBuzz(2));
            Assert.AreEqual("Fizz", Program.FizzBuzz(3));
            Assert.AreEqual("4", Program.FizzBuzz(4));
            Assert.AreEqual("Fizz", Program.FizzBuzz(6));
        }

        [TestMethod()]
        public void FizzBuzzTest2()
        {
            Assert.AreEqual("1", Program.FizzBuzz(1));
            Assert.AreEqual("2", Program.FizzBuzz(2));
            Assert.AreEqual("Fizz", Program.FizzBuzz(3));
            Assert.AreEqual("4", Program.FizzBuzz(4));
            Assert.AreEqual("Buzz", Program.FizzBuzz(5));
            Assert.AreEqual("Fizz", Program.FizzBuzz(6));
            Assert.AreEqual("Buzz", Program.FizzBuzz(10));
        }

        [TestMethod()]
        public void FizzBuzzTest3()
        {
            Assert.AreEqual("1", Program.FizzBuzz(1));
            Assert.AreEqual("2", Program.FizzBuzz(2));
            Assert.AreEqual("Fizz", Program.FizzBuzz(3));
            Assert.AreEqual("4", Program.FizzBuzz(4));
            Assert.AreEqual("Buzz", Program.FizzBuzz(5));
            Assert.AreEqual("Fizz", Program.FizzBuzz(6));
            Assert.AreEqual("Buzz", Program.FizzBuzz(10));
            Assert.AreEqual("FizzBuzz", Program.FizzBuzz(15));
            Assert.AreEqual("FizzBuzz", Program.FizzBuzz(30));
        }

    }
}