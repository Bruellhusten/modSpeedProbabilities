using generateTries.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace generateTries.Application
{
    public class Strategy
    {
        public List<SpeedResult> SpeedResults { get; }
        public int Days { get; set; }
        public StrategyDTO StrategyDTO { get; set; }
        private const int REFRESH_ENERGY = 120;
        public Strategy(StrategyDTO strategyDTO, int days)
        {
            SpeedResults = DataGenerator.PopulateSpeedResults(10);
            Days = days;
            StrategyDTO = strategyDTO;
        }
        public StrategyResult EvaluateStrategy()
        {
            var filteredSpeedResults = GetFilteredSpeedResults(StrategyDTO);
            var dailyEnergy = GetDailyEnergy();
            var plus10Mods = filteredSpeedResults.FindAll(f => f.Speed >= 10 && f.Speed < 15);
            var plus15Mods = filteredSpeedResults.FindAll(f => f.Speed >= 15 && f.Speed < 20);
            var plus20Mods = filteredSpeedResults.FindAll(f => f.Speed >= 20 && f.Speed < 25);
            var plus25Mods = filteredSpeedResults.FindAll(f => f.Speed >= 25 && f.Speed < 30);
            return new StrategyResult
            {
                PassedDays = Days,
                SumOfPlus10Mods = plus10Mods.Sum(m => m.Probability) * dailyEnergy * Days,
                SumOfPlus15Mods = plus15Mods.Sum(m => m.Probability) * dailyEnergy * Days,
                SumOfPlus20Mods = plus20Mods.Sum(m => m.Probability) * dailyEnergy * Days,
                SumOfPlus25Mods = plus25Mods.Sum(m => m.Probability) * dailyEnergy * Days,
            };
          
        }

   

        private decimal GetDailyEnergy()
        {
            var slicingMaterial = new SlicingMaterial();
            return StrategyDTO.DailyShipEnergy
                                + slicingMaterial.CrystalToEnergyEquivalent * StrategyDTO.DailySlicingCrystal
                                + StrategyDTO.ShipEnergyRefreshes * REFRESH_ENERGY;
        }

        private List<SpeedResult> GetFilteredSpeedResults(StrategyDTO strategy)
        {

            foreach (var speedResult in SpeedResults)
            {
                var combinationsToRemove = new List<Combination>();
                EvaluateCombinations(strategy, speedResult, combinationsToRemove);
                RemoveCombinations(speedResult, combinationsToRemove);
            }
            return SpeedResults;
        }

        private static void EvaluateCombinations(StrategyDTO strategy, SpeedResult speedResult, List<Combination> combinationsToRemove)
        {
            foreach (var combination in speedResult.PossibleCombinations)
            {
                if (strategy.GreyThreshold > combination.Mod.InitialSpeed
                    || strategy.GreenThreshold > combination.Mod.GreenSpeed
                    || strategy.BlueThreshold > combination.Mod.BlueSpeed
                    || strategy.PurpleThreshold > combination.Mod.PurpleSpeed)
                {
                    combinationsToRemove.Add(combination);
                }
            }
        }

        private static void RemoveCombinations(SpeedResult speedResult, List<Combination> combinationsToRemove)
        {
            foreach (var combinationToRemove in combinationsToRemove)
            {
                speedResult.PossibleCombinations.Remove(combinationToRemove); ;
            }
        }
    }
}
