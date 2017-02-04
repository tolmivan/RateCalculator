using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RateCalculator.Model;

namespace RateCalculator.Test
{
    [TestClass]
    public class StandardRateTest
    {
        [TestMethod]
        public void Test1hr()
        {
            StandardRate rate = new StandardRate();

            DateTime entry = Convert.ToDateTime("01/08/2008 07:00:00");
            DateTime exit = Convert.ToDateTime("01/08/2008 07:59:00");

            Assert.AreEqual(5, rate.GetTotalCost(entry, exit));
        }

        [TestMethod]
        public void Test2hr()
        {
            StandardRate rate = new StandardRate();

            DateTime entry = Convert.ToDateTime("01/08/2008 07:00:00");
            DateTime exit = Convert.ToDateTime("01/08/2008 08:59:00");

            Assert.AreEqual(10, rate.GetTotalCost(entry, exit));
        }

        [TestMethod]
        public void Test3hr()
        {
            StandardRate rate = new StandardRate();

            DateTime entry = Convert.ToDateTime("01/08/2008 07:00:00");
            DateTime exit = Convert.ToDateTime("01/08/2008 09:59:00");

            Assert.AreEqual(15, rate.GetTotalCost(entry, exit));
        }

        [TestMethod]
        public void Test5hr()
        {
            StandardRate rate = new StandardRate();

            DateTime entry = Convert.ToDateTime("01/08/2008 07:00:00");
            DateTime exit = Convert.ToDateTime("01/08/2008 11:59:00");

            Assert.AreEqual(20, rate.GetTotalCost(entry, exit));
        }

        [TestMethod]
        public void Test1d1hr()
        {
            StandardRate rate = new StandardRate();

            DateTime entry = Convert.ToDateTime("01/08/2008 07:00:00");
            DateTime exit = Convert.ToDateTime("02/08/2008 07:59:00");

            Assert.AreEqual(25, rate.GetTotalCost(entry, exit));
        }


    }
}
