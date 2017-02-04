using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class RateBase
    {
        public string RateName { get; protected set; }
        public RateTypes RateType { get; protected set; }
        public decimal RateAmount { get; protected set; }
        public string Notes { get; protected set; }
        public abstract decimal? GetTotal(DateTime entryTime, DateTime exitTime);

        public abstract bool VerifyRateApplies(DateTime entryTime, DateTime exitTime);

        public bool ValidateEntry(DateTime entryTime, DateTime exitTime)
        {
            // a basic check to make sure exit happens after entry
            if (exitTime > entryTime)
                return true;

            return false;
        }
    }

    public enum RateTypes
    {
        FlatRate,
        HourlyRate
    }
}
