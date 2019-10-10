using generateTries.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace generateTries.Application
{
    public class StrategyDataGenerator : DataGenerator
    {
        public StrategyDTO Strategy { get; set; }
        private const int REFRESH_ENERGY = 120;

        public StrategyDataGenerator(StrategyDTO strategy)
        {
            Strategy = strategy;
        }

        public override void GenerateResultLines(List<SpeedResult> results, int speed)
        {
            var possibleCombinations = base.GeneratePossibleCombinations(speed);
            results.Add(new SpeedResult()
            {
                Speed = speed,
                PossibleCombinations = possibleCombinations,
                Probability = possibleCombinations.Sum(x => x.Probability()),
                ModCount = possibleCombinations.Sum(x => x.AmountOfModsForEnergy(Strategy, GetEnergy()))
            });
        }

        private decimal GetEnergy()
        {
            var slicingMaterial = new SlicingMaterial();
            return (Strategy.DailyModEnergy
                        + slicingMaterial.CrystalToEnergyEquivalent * Strategy.DailySlicingCrystal
                        + Strategy.ShipEnergyRefreshes * REFRESH_ENERGY)
                            * Strategy.Days;
        }
    }
}
