using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RateCalculator.Model;

namespace RateCalculator.Test
{
    [TestClass]
    public class NightRateTest
    {
        [TestMethod]
        public void TestValidRangeSameNight()
        {
            NightRate rate = new NightRate();

            DateTime entry = Convert.ToDateTime("01/08/2008 19:00:00");
            DateTime exit = Convert.ToDateTime("01/08/2008 20:00:00");

            Assert.AreEqual(6.50M, rate.GetTotal(entry, exit));
        }

        [TestMethod]
        public void TestValidRangeExitNextMorning()
        {
            NightRate rate = new NightRate();

            DateTime entry = Convert.ToDateTime("01/08/2008 19:00:00");
            DateTime exit = Convert.ToDateTime("02/08/2008 05:00:00");

            Assert.AreEqual(6.50M, rate.GetTotal(entry, exit));
        }

        [TestMethod]
        public void TestInValidRangeExitNextMorning()
        {
            NightRate rate = new NightRate();

            DateTime entry = Convert.ToDateTime("01/08/2008 19:00:00");
            DateTime exit = Convert.ToDateTime("02/08/2008 06:01:00");

            Assert.AreEqual(null, rate.GetTotal(entry, exit));
        }

        [TestMethod]
        public void TestInValidRangeExitAfter2Days()
        {
            NightRate rate = new NightRate();

            DateTime entry = Convert.ToDateTime("01/08/2008 19:00:00");
            DateTime exit = Convert.ToDateTime("03/08/2008 05:00:00");

            Assert.AreEqual(null, rate.GetTotal(entry, exit));
        }



        [TestMethod]
        public void TestInvalidRange()
        {
            NightRate rate = new NightRate();

            DateTime entry = Convert.ToDateTime("01/08/2008 07:00:00");
            DateTime exit = Convert.ToDateTime("01/08/2008 15:00:00");

            Assert.AreEqual(null, rate.GetTotal(entry, exit));

        }
    }
}
