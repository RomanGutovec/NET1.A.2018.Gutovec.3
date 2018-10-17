using System;
using NUnit.Framework;

namespace AlgorithmsLib.NUnit.Tests
{
    [TestFixture]
    public class AlgorithmLibNunitTest
    {
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double FindNthRootMethod(double number, int power, double accuracy)
        {
            return Math.Round(AlgorithmsLib.FindNthRoot(number, power, accuracy), accuracy.ToString().Length - 2);
        }

        [Test]
        public void FindNthRootMethodTest_WithData_negative0dot01_2__0dot0001ThrowArgumentException()
            => Assert.Throws<ArgumentException>(() => AlgorithmsLib.FindNthRoot(-0.01, 2, 0.0001));
        [Test]
        public void FindNthRootMethodTest_WithData_0dot001_neg2__0dot0001ThrowArgumentException()
            => Assert.Throws<ArgumentException>(() => AlgorithmsLib.FindNthRoot(0.001, -2, 0.0001));
        [Test]
        public void FindNthRootMethodTest_WithData_0dot01_2__neg1ThrowArgumentException()
           => Assert.Throws<ArgumentException>(() => AlgorithmsLib.FindNthRoot(0.01, 2, -1));

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        public int FindNextBiggerMethod(int number)
            => AlgorithmsLib.FindNextBigger(number);
    }
}
