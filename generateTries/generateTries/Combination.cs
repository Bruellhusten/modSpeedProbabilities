using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries
{
    public class Combination
    {
        public InitialSpeed Init { get; set; }
        public SlicingIncrease ToGreen { get; set; }
        public SlicingIncrease ToBlue { get; set; }
        public SlicingIncrease ToPurple { get; set; }
        public SlicingIncrease ToGold { get; set; }

        public int Speed()
        {
            return Init.Speed + ToGreen.Increase + ToBlue.Increase + ToPurple.Increase + ToGold.Increase;
        }

        public decimal Probability()
        {
            return Init.Probability * ToGreen.Probability * ToBlue.Probability * ToPurple.Probability * ToGold.Probability;
        }
    }
}
