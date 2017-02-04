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
            string rateName;


            Assert.AreEqual(13, myCalculator.Calculate(entry, exit, out rateName));
        }

        [TestMethod]
        public void TestCalculatorWeekendVsNightRate()
        {
            IRate weekendRate = new WeekendRate();
            IRate nightRate = new NightRate();
            IRate standardRate = new StandardRate();


            List<IRate> myRates = new List<IRate>();

            myRates.Add(weekendRate);
            myRates.Add(nightRate);
            myRates.Add(standardRate);

            Calculator myCalculator = new Calculator(myRates);

            DateTime entry = Convert.ToDateTime("03/02/2017 23:00:00");
            DateTime exit = Convert.ToDateTime("04/02/2017 5:00:00");
            string rateName;


            Assert.AreEqual(6.50M, myCalculator.Calculate(entry, exit, out rateName));
            Assert.AreEqual("Night", rateName);
        }

    }
}
