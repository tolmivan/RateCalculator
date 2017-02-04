using RateCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.Client
{
    /// <summary>
    /// Represents a client with a particular set of rates (night rate disabled)
    /// </summary>
    public class ClientTwo
    {
        private List<IRate> _myRates;
        private Calculator _myCalculator;
        public ClientTwo()
        {
            IRate myStandardRate = new StandardRate();
            IRate mySpecialRate = new EarlyBirdRate();
            IRate myNightRate = new NightRate();
            ((NightRate)(myNightRate)).IsActive = false;
            IRate myWeekendRate = new WeekendRate();

            _myRates = new List<IRate>();

            _myRates.Add(mySpecialRate);
            _myRates.Add(myStandardRate);
            _myRates.Add(myNightRate);
            _myRates.Add(myWeekendRate);


            _myCalculator = new Calculator(_myRates);
        }

        public string Calculate(DateTime entryTime, DateTime exitTime)
        {
            decimal? cost = _myCalculator.Calculate(entryTime, exitTime);

            if (cost.HasValue)
                return string.Format("ClientTwo cost:{0:c}", cost);
            else
                return "There was a problem calculating the cost, please call ClientTwo support.";
        }

    }
}
