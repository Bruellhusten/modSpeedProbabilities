using generateTries.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries.Application
{
    public class Strategy
    {
        public static StrategyResult EvaluateStrategy(StrategyDTO strategy, int days)
        {
            var filteredSpeedResults = GetFilteredSpeedResults(strategy);

            var result = new StrategyResult
            {
                PassedDays = days,
            };
            return result;
        }

        private static List<SpeedResult> GetFilteredSpeedResults(StrategyDTO strategy)
        {
            var speedResults = DataGenerator.PopulateSpeedResults(10);

            foreach (var speedResult in speedResults)
            {
                var combinationsToRemove = new List<Combination>();
                EvaluateCombinations(strategy, speedResult, combinationsToRemove);
                RemoveCombinations(speedResult, combinationsToRemove);
            }
            return DataGenerator.PopulateSpeedResults(10);
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
