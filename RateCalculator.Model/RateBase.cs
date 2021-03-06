﻿using System;
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
        public bool IsActive { get; set; } = true;
        protected bool IsSpecial { get; set; }

        public decimal? GetTotalCost(DateTime entryTime, DateTime exitTime)
        {
            if (!ValidateEntry(entryTime, exitTime))
                return null;

            return GetTotal(entryTime, exitTime);
        }

        protected abstract decimal? GetTotal(DateTime entryTime, DateTime exitTime);

        protected abstract bool VerifyRateApplies(DateTime entryTime, DateTime exitTime);

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

        public string GetRateName()
        {
            return RateName;
        }
    }

}
