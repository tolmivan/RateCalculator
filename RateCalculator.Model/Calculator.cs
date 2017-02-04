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

        public decimal? Calculate(DateTime entryTime, DateTime exitTime)
        {
            // first calculate a cost based on discounted rates
            decimal? specialCost = FindMinimumCost(_rates.Where(x => (x.IsActive() && x.IsSpecial())), entryTime, exitTime);

            if (specialCost.HasValue)
            {
                return specialCost.Value;
            }
            else
            {
                // if no special rate found - return the cost based on standard rates
                return FindMinimumCost(_rates.Where(x => (!x.IsActive() && x.IsSpecial())), entryTime, exitTime);
            }
        }



        /// <summary>
        /// Helper function to calculate cost using given rate array
        /// </summary>
        /// <param name="rates"></param>
        /// <param name="entryTime"></param>
        /// <param name="exitTime"></param>
        /// <returns></returns>
        private decimal? FindMinimumCost(IEnumerable<IRate> rates, DateTime entryTime, DateTime exitTime)
        {
            decimal? cost = null;

            foreach (IRate rate in rates)
            {
                decimal? currentCost = rate.GetTotal(entryTime, exitTime);
                if (currentCost.HasValue)
                {
                    if (cost == null || currentCost.Value < cost)
                    {
                        cost = currentCost.Value;
                    }
                }
            }

            return cost;
        }
    }
}
