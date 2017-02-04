using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RateCalculator.Model;

namespace RateCalculator.Test
{
    [TestClass]
    public class EarlyBirdTest
    {
        [TestMethod]
        public void TestValidRange()
        {
            EarlyBirdRate rate = new EarlyBirdRate();

            DateTime entry = Convert.ToDateTime("01/08/2008 07:00:00");
            DateTime exit = Convert.ToDateTime("01/08/2008 16:00:00");

            Assert.AreEqual(13, rate.GetTotal(entry, exit));
        }

        [TestMethod]
        public void TestInvalidRange()
        {
            EarlyBirdRate rate = new EarlyBirdRate();

            DateTime entry = Convert.ToDateTime("01/08/2008 07:00:00");
            DateTime exit = Convert.ToDateTime("01/08/2008 15:00:00");

            Assert.AreEqual(null, rate.GetTotal(entry, exit));

        }
    }
}
