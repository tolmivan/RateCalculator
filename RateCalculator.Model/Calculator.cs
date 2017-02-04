using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.Model
{
    /// <summary>
    /// make use of all rates available to calculate the cost of parking to try to get a minimal one to keep the patrons happy
    /// </summary>
    public class Calculator
    {
        private IEnumerable<IRate> _rates;
        public Calculator(IEnumerable<IRate> rates)
        {
            _rates = rates;
        }

        public decimal? Calculate(DateTime entryTime, DateTime exitTime, out string appliedRateName)
        {
            appliedRateName = string.Empty;

            // first calculate a cost based on discounted rates
            decimal? specialCost = FindMinimumCost(_rates.Where(x => (x.IsActive() && x.IsSpecial())), entryTime, exitTime, out appliedRateName);

            if (specialCost.HasValue)
            {
                return specialCost.Value;
            }
            else
            {
                // if no special rate found - return the cost based on standard rates
                return FindMinimumCost(_rates.Where(x => (x.IsActive() && !x.IsSpecial())), entryTime, exitTime, out appliedRateName);
            }
        }



        /// <summary>
        /// Helper function to calculate cost using given rate array
        /// </summary>
        /// <param name="rates"></param>
        /// <param name="entryTime"></param>
        /// <param name="exitTime"></param>
        /// <returns></returns>
        private decimal? FindMinimumCost(IEnumerable<IRate> rates, DateTime entryTime, DateTime exitTime, out string rateName)
        {
            decimal? cost = null;
            rateName = string.Empty;

            foreach (IRate rate in rates)
            {
                decimal? currentCost = rate.GetTotal(entryTime, exitTime);
                if (currentCost.HasValue)
                {
                    if (cost == null || currentCost.Value < cost)
                    {
                        cost = currentCost.Value;
                        rateName = rate.GetRateName();
                    }
                }
            }

            return cost;
        }
    }
}
