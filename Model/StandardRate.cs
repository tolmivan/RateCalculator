using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StandardRate : RateBase
    {

        private const decimal DefaultDailyRate = 20;
        private const decimal Default1HourRate = 5;
        private const decimal Default2HourRate = 10;
        private const decimal Default3HourRate = 15;

        public StandardRate()
        {
            this.RateName = "Standard Rate";
            this.RateType = RateTypes.HourlyRate;
            this.Notes = "0 – 1 hours $5.00\n1 – 2 hours $10.00\n2 – 3 hours $15.00\n3 + hours $20.00 flat rate per day for each day of parking.";
        }
        public override decimal? GetTotal(DateTime entryTime, DateTime exitTime)
        {
            decimal rate = 0;

            TimeSpan duration = exitTime.Subtract(entryTime);

            // calculate daily rate, cast truncates the fractional part
            int days = (int)duration.TotalDays;
            rate = days * DefaultDailyRate;

            // calculate hourly rate
            double hours = duration.Subtract(new TimeSpan(days, 0, 0, 0)).TotalHours;

            if(hours > 3)
            {
                rate += DefaultDailyRate;
            }
            else if(hours > 2)
            {
                rate += Default3HourRate;
            }
            else if(hours > 1)
            {
                rate += Default2HourRate;
            }
            else
            {
                rate += Default1HourRate;
            }

            return rate;
        }

        public override bool VerifyRateApplies(DateTime entryTime, DateTime exitTime)
        {
            if(base.ValidateEntry(entryTime, exitTime))
            {
                // standard rates can be applied to any valid entry/exit
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
