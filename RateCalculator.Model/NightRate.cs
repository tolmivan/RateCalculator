using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.Model
{
    public class NightRate : RateBase
    {
        #region Rate Specific Consts
        // keeping rate specific constants at the top for readability
        private readonly TimeSpan _startEntry = new TimeSpan(18, 0, 0);
        private readonly TimeSpan _endEntry = new TimeSpan(24, 0, 0);
        private readonly TimeSpan _startExit = new TimeSpan(18, 0, 0);
        private readonly TimeSpan _endExit = new TimeSpan(30, 0, 0);

        private const decimal DefaultRate = 6.50M;

        #endregion Rate Specific Consts

        public NightRate() : this(DefaultRate) { }
        
        public NightRate(decimal dailyRate)
        {
            this.RateName = "Night";
            this.IsSpecial = true;
            this.RateType = RateTypes.FlatRate;
            this.RateAmount = dailyRate;
            this.Notes = "Enter between 6:00 PM to 12:00 AM\nExit before 6 AM the following day";
        }
        protected override decimal? GetTotal(DateTime entryTime, DateTime exitTime)
        {
            if (!VerifyRateApplies(entryTime, exitTime))
                return null;


            return this.RateAmount;
        }

        protected override bool VerifyRateApplies(DateTime entryTime, DateTime exitTime)
        {
            TimeSpan actualEntry = entryTime.TimeOfDay;
            TimeSpan actualExit = exitTime.TimeOfDay;

            if (exitTime.Date > entryTime.Date)
                actualExit = actualExit.Add(new TimeSpan(1, 0, 0, 0));

            if (exitTime.Date > entryTime.Date.AddDays(1))
            {
                return false;
            }

            // check if entry time falls between the right interval
            if ((actualEntry >= _startEntry) && (actualEntry <= _endEntry))
            {
                // check exit time
                if ((actualExit >= _startExit) && (actualExit <= _endExit))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
