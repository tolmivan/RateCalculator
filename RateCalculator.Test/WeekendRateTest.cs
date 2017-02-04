using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RateCalculator.Model;

namespace RateCalculator.Test
{
    [TestClass]
    public class WeekendRateTest
    {
        [TestMethod]
        public void TestValidRangeSaturday()
        {
            WeekendRate rate = new WeekendRate();

            DateTime entry = Convert.ToDateTime("04/02/2017 8:00:00");
            DateTime exit = Convert.ToDateTime("04/02/2017 20:00:00");

            Assert.AreEqual(10M, rate.GetTotal(entry, exit));
        }

        [TestMethod]
        public void TestValidRangeSatToSun()
        {
            WeekendRate rate = new WeekendRate();

            DateTime entry = Convert.ToDateTime("04/02/2017 8:00:00");
            DateTime exit = Convert.ToDateTime("05/02/2017 20:00:00");

            Assert.AreEqual(10M, rate.GetTotal(entry, exit));
        }

        [TestMethod]
        public void TestValidRangeFriToSun()
        {
            WeekendRate rate = new WeekendRate();

            DateTime entry = Convert.ToDateTime("04/02/2017 1:00:00");
            DateTime exit = Convert.ToDateTime("05/02/2017 20:00:00");

            Assert.AreEqual(10M, rate.GetTotal(entry, exit));
        }

        [TestMethod]
        public void TestInValidRangeFriToSun()
        {
            WeekendRate rate = new WeekendRate();

            DateTime entry = Convert.ToDateTime("03/02/2017 23:00:00");
            DateTime exit = Convert.ToDateTime("05/02/2017 20:00:00");

            Assert.AreEqual(null, rate.GetTotal(entry, exit));
        }

        [TestMethod]
        public void TestInValidRangeWedToTh()
        {
            WeekendRate rate = new WeekendRate();

            DateTime entry = Convert.ToDateTime("01/02/2017 8:00:00");
            DateTime exit = Convert.ToDateTime("02/02/2017 8:00:00");

            Assert.AreEqual(null, rate.GetTotal(entry, exit));
        }


    }
}
