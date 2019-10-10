using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries.Domain
{
    public class Combination
    {
        public InitialSpeed Init { get; set; }
        public SlicingIncrease ToGreen { get; set; }
        public SlicingIncrease ToBlue { get; set; }
        public SlicingIncrease ToPurple { get; set; }
        public SlicingIncrease ToGold { get; set; }
        public Mod Mod { get; set; }

        public decimal Probability()
        {
            return Init.Probability * ToGreen.Probability * ToBlue.Probability * ToPurple.Probability * ToGold.Probability;
        }

        public decimal EnergyCost(StrategyDTO strategy)
        {
            var slicingCosts = new SlicingCosts();

            if (Init.Speed < strategy.GreyThreshold)
            {
                return Mod.InitialEnergyCost;
            }
            if (Mod.GreenSpeed < strategy.GreenThreshold)
            {
                return Mod.InitialEnergyCost + slicingCosts.ToGreen;
            }
            if (Mod.BlueSpeed < strategy.BlueThreshold)
            {
                return Mod.InitialEnergyCost + slicingCosts.ToGreen + slicingCosts.ToBlue;
            }
            if (Mod.PurpleSpeed < strategy.PurpleThreshold)
            {
                return Mod.InitialEnergyCost + slicingCosts.ToGreen + slicingCosts.ToBlue + slicingCosts.ToPurple;
            }

            return Mod.InitialEnergyCost + slicingCosts.ToGreen + slicingCosts.ToBlue + slicingCosts.ToPurple + slicingCosts.ToGold;
        }

        public decimal AmountOfModsForEnergy(StrategyDTO strategy, decimal energy)
        {
            return Probability() * energy / EnergyCost(strategy);
        }
    }
}
