using RateCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.Client
{
    /// <summary>
    /// Represents a client with a particular set of rates
    /// </summary>
    public class ClientOne
    {
        private List<IRate> _myRates;
        private Calculator _myCalculator;
        public ClientOne()
        {
            IRate myStandardRate = new StandardRate();
            IRate mySpecialRate = new EarlyBirdRate();

            _myRates = new List<IRate>();

            _myRates.Add(mySpecialRate);
            _myRates.Add(mySpecialRate);

            _myCalculator = new Calculator(_myRates);
        }

        public string Calculate(DateTime entryTime, DateTime exitTime)
        {
            decimal? cost = _myCalculator.Calculate(entryTime, exitTime);

            if (cost.HasValue)
                return string.Format("ClientOne cost:{0:c}", cost);
            else
                return "There was a problem calculating the cost, please call ClientOne support.";
        }

    }
}
