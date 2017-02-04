using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.Model
{
    public abstract class RateBase : IRate
    {
        public string RateName { get; protected set; }
        public RateTypes RateType { get; protected set; }
        public decimal RateAmount { get; protected set; }
        public string Notes { get; protected set; }
        protected bool IsActive { get; set; } = true;
        protected bool IsSpecial { get; set; }

        public abstract decimal? GetTotal(DateTime entryTime, DateTime exitTime);

        public abstract bool VerifyRateApplies(DateTime entryTime, DateTime exitTime);

        public bool ValidateEntry(DateTime entryTime, DateTime exitTime)
        {
            // a basic check to make sure exit happens after entry
            if (exitTime > entryTime)
                return true;

            return false;
        }

        bool IRate.IsActive()
        {
            return IsActive;
        }

        bool IRate.IsSpecial()
        {
            return IsSpecial;
        }
    }

}
