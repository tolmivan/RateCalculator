using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EarlyBirdRate : RateBase
    {
        // keeping rate specific constants at the top for readability
        private readonly TimeSpan _startEntry = new TimeSpan(6, 0, 0);
        private readonly TimeSpan _endEntry = new TimeSpan(9, 0, 0);
        private readonly TimeSpan _startExit = new TimeSpan(15, 30, 0);
        private readonly TimeSpan _endExit = new TimeSpan(11, 30, 0);

        private const decimal DefaultRate = 13;

        public EarlyBirdRate() : this(DefaultRate) { }
        
        public EarlyBirdRate(decimal dailyRate)
        {
            this.RateName = "Early Bird";
            this.RateType = RateTypes.FlatRate;
            this.RateAmount = dailyRate;
            this.Notes = "Enter between 6:00 AM to 9:00 AM\nExit between 3:30 PM to 11:30 PM";
        }
        public override decimal? GetTotalPrice(DateTime entryTime, DateTime exitTime)
        {
            if (!VerifyRateApplies(entryTime, exitTime))
                return null;


            return this.RateAmount;
        }

        /// <summary>
        /// Entry time between 6am and 9am, exit time between 3:30 to 11:30 pm
        /// assumed to be weekdays only but it is not stated explicitly
        /// we will be calculating rates using all possible options and returning minimal one to make sure
        /// the patrons are not overcharged so we can ignore checking for week day.
        /// It is not specified that the rate applies only if patrons exit the same day
        /// but common sense is it should be so implement this way until requeted otherwise.
        /// </summary>
        /// <param name="entryTime"></param>
        /// <param name="exitTime"></param>
        /// <returns></returns>
        public override bool VerifyRateApplies(DateTime entryTime, DateTime exitTime)
        {
            TimeSpan actualEntry = entryTime.TimeOfDay;
            TimeSpan actualExit = entryTime.TimeOfDay;

            if (entryTime.Date != exitTime.Date)
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
