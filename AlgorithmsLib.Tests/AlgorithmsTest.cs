using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsLib.Tests
{
    [TestClass()]
    public class AlgorithmsDDT_Tests
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\AlgorithmsTestsXML.xml",
            "testCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("AlgorithmsLib.Tests\\AlgorithmsTestsXML.xml")]
        [TestMethod]
        public void FindNthRootMethodTest_DataSourceFileAlgorithmsTestXML()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            double number = Convert.ToDouble(TestContext.DataRow["number"]);
            int power = Convert.ToInt32(TestContext.DataRow["power"]);
            double accurancy = Convert.ToDouble(TestContext.DataRow["accurancy"]);
            double expected = Convert.ToDouble(TestContext.DataRow["expectedResult"]);
            Assert.AreEqual(expected, AlgorithmsLib.FindNthRoot(number, power, accurancy), accurancy);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRootMethodTest_WithData_negative0dot01_2__0dot0001ThrowArgumentException()
            => AlgorithmsLib.FindNthRoot(-0.01, 2, 0.0001);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRootMethodTest_WithData_0dot001_neg2__0dot0001ThrowArgumentException()
            => AlgorithmsLib.FindNthRoot(0.001, -2, 0.0001);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRootMethodTest_WithData_0dot01_2__neg1ThrowArgumentException()
            => AlgorithmsLib.FindNthRoot(0.01, 2, -1);
    }
}
