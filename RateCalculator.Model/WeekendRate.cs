using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.Model
{
    public class WeekendRate : RateBase
    {
        #region Rate Specific Consts
        // keeping rate specific constants at the top for readability
        private readonly TimeSpan _startEntry = new TimeSpan(5, 0, 0, 0);
        private readonly TimeSpan _endEntry = new TimeSpan(7, 24, 0, 0);
        private readonly TimeSpan _startExit = new TimeSpan(5, 0, 0, 0);
        private readonly TimeSpan _endExit = new TimeSpan(7, 24, 0, 0);

        private const decimal DefaultRate = 10M;

        #endregion Rate Specific Consts

        public WeekendRate() : this(DefaultRate) { }
        
        public WeekendRate(decimal dailyRate)
        {
            this.RateName = "Weekend";
            this.IsSpecial = true;
            this.RateType = RateTypes.FlatRate;
            this.RateAmount = dailyRate;
            this.Notes = "Enter anytime past midnight on Friday to Sunday\nExit any time before midnight of Sunday";
        }
        protected override decimal? GetTotal(DateTime entryTime, DateTime exitTime)
        {
            if (!VerifyRateApplies(entryTime, exitTime))
                return null;


            return this.RateAmount;
        }

        protected override bool VerifyRateApplies(DateTime entryTime, DateTime exitTime)
        {
            // set the timespans with days starting from monday, and sunday correction
            int entryDayOfweek = (int)entryTime.DayOfWeek;
            if (entryDayOfweek == 0)
                entryDayOfweek = 7;
            int exitDayOfweek = (int)exitTime.DayOfWeek;
            if (exitDayOfweek == 0)
                exitDayOfweek = 7;

            TimeSpan actualEntry = entryTime.TimeOfDay.Add(new TimeSpan(entryDayOfweek, 0,0,0));
            TimeSpan actualExit = exitTime.TimeOfDay.Add(new TimeSpan(exitDayOfweek, 0, 0, 0));


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
