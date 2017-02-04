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
        public abstract decimal? GetTotalPrice(DateTime entryTime, DateTime exitTime);

        public abstract bool VerifyRateApplies(DateTime entryTime, DateTime exitTime);
    }

    public enum RateTypes
    {
        FlatRate,
        HourlyRate
    }
}
