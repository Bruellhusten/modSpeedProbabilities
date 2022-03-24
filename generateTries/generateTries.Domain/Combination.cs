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

        public decimal EnergyCost(StrategyDTO strategy, ModGrade grade)
        {
            var slicingCosts = new SlicingCosts(grade);

            if (Init.Speed < strategy.GreyThreshold && grade <= ModGrade.Grey)
            {
                return Mod.InitialEnergyCost;
            }
            if (Mod.GreenSpeed < strategy.GreenThreshold && grade <= ModGrade.Green)
            {
                return Mod.InitialEnergyCost + slicingCosts.ToGreen;
            }
            if (Mod.BlueSpeed < strategy.BlueThreshold && grade <= ModGrade.Blue)
            {
                return Mod.InitialEnergyCost + slicingCosts.ToGreen + slicingCosts.ToBlue;
            }
            if (Mod.PurpleSpeed < strategy.PurpleThreshold && grade <= ModGrade.Purple)
            {
                return Mod.InitialEnergyCost + slicingCosts.ToGreen + slicingCosts.ToBlue + slicingCosts.ToPurple;
            }

            return Mod.InitialEnergyCost + slicingCosts.ToGreen + slicingCosts.ToBlue + slicingCosts.ToPurple + slicingCosts.ToGold;
        }

        public decimal AmountOfModsForEnergy(StrategyDTO strategy, decimal energy)
        {
            var probability = Probability();

            var initialGreyMods = probability * energy * InitialModQuality.Grey / EnergyCost(strategy, ModGrade.Grey);
            var initialGreenMods = probability * energy * InitialModQuality.Green / EnergyCost(strategy, ModGrade.Green);
            var initialBlueMods = probability * energy * InitialModQuality.Blue / EnergyCost(strategy, ModGrade.Blue);
            var initialPurpleMods = probability * energy * InitialModQuality.Purple / EnergyCost(strategy, ModGrade.Purple);
            var initialGoldMods = probability * energy * InitialModQuality.Gold / EnergyCost(strategy, ModGrade.Gold);

            return initialGreyMods + initialGreenMods + initialBlueMods + initialPurpleMods + initialGoldMods;
        }
    }
}
