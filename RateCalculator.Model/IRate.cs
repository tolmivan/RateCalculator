using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateCalculator.Model
{
    public interface IRate
    {
        bool IsActive();
        bool IsSpecial();
        decimal? GetTotal(DateTime entryTime, DateTime exitTime);
    }
}
