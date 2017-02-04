using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RateCalculator.Model;
using System.Collections.Generic;

namespace RateCalculator.Test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void TestCalculatorWithEarlyBirdRate()
        {
            IRate mySpecialRate = new EarlyBirdRate();

            List<IRate>  myRates = new List<IRate>();

            myRates.Add(mySpecialRate);

            Calculator myCalculator = new Calculator(myRates);

            DateTime entry = Convert.ToDateTime("01/08/2008 07:00:00");
            DateTime exit = Convert.ToDateTime("01/08/2008 16:00:00");


            Assert.AreEqual(13, myCalculator.Calculate(entry, exit));
        }
    }
}
