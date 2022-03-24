using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries.Domain
{
    public class StrategyResult
    {
        public int PassedDays { get; set; }
        public decimal SumOfPlus10Mods { get; set; }
        public decimal SumOfPlus15Mods { get; set; }
        public decimal SumOfPlus20Mods { get; set; }
        public decimal SumOfPlus25Mods { get; set; }

        public StrategyResult()
        {
            PassedDays = 30;
            SumOfPlus10Mods = 0;
            SumOfPlus15Mods = 0;
            SumOfPlus20Mods = 0;
            SumOfPlus25Mods = 0;
        }
    }
}
