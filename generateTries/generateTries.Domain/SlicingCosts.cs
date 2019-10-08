using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries.Domain
{
    public class SlicingCosts
    {
        public int ToGreen { get; }
        public int ToBlue { get; }
        public int ToPurple { get; }
        public int ToGold { get; }
        public decimal AverageSlicingCosts { get; set; }
        public StrategyDTO Strategy { get; set; }

        public SlicingCosts()
        {
            ToGreen = 10;
            ToBlue = 20;
            ToPurple = 35;
            ToGold = 50;
            //AverageSlicingCosts = CalculateAverageSlicingCosts();
        }

        public SlicingCosts(Combination combination)
        {

        }

        private decimal CalculateAverageSlicingCosts(StrategyDTO strategy)
        {
            Strategy = strategy;
            var grey = CalculateFromGrey();
            return 0M;
        }

        private decimal CalculateFromGrey()
        {
            
            return 0M;
        }
    }
}
