using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StandardRate : RateBase
    {
        public StandardRate()
        {
            this.RateName = "Standard Rate";
            this.RateType = RateTypes.HourlyRate;
            this.Notes = "0 – 1 hours $5.00\n1 – 2 hours $10.00\n2 – 3 hours $15.00\n3 + hours $20.00 flat rate per day for each day of parking.";
        }
        public override decimal? GetTotalPrice(DateTime entryTime, DateTime exitTime)
        {
            throw new NotImplementedException();
        }

        public override bool VerifyRateApplies(DateTime entryTime, DateTime exitTime)
        {
            throw new NotImplementedException();
        }
    }
}
