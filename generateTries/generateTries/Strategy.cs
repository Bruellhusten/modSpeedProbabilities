using generateTries.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace generateTries.Application
{
    public class Strategy
    {
        private readonly List<SpeedResult> SpeedResults;
        private readonly StrategyDTO StrategyDTO;
        public decimal ModsCollected { get; set; } = 0;
        public decimal ModsSold { get; set; } = 0;
        public decimal ModsSoldTemp { get; set; } = 0;


        public Strategy(StrategyDTO strategyDTO)
        {
            var generator = new StrategyDataGenerator(strategyDTO);
            SpeedResults = generator.PopulateSpeedResults(10);
            StrategyDTO = strategyDTO;
            ModsCollected = SpeedResults.Sum(r => r.ModCount);
        }

        public StrategyResult EvaluateStrategy()
        {
            var gold = EvaluateModsByGrade(ModGrade.Gold);
            var purple = EvaluateModsByGrade(ModGrade.Purple);
            var blue = EvaluateModsByGrade(ModGrade.Blue);
            var green = EvaluateModsByGrade(ModGrade.Green);
            var grey = EvaluateModsByGrade(ModGrade.Grey);
            
            return new StrategyResult
            {
                PassedDays = StrategyDTO.Days,
                SumOfPlus10Mods = grey.SumOfPlus10Mods + green.SumOfPlus10Mods + blue.SumOfPlus10Mods + purple.SumOfPlus10Mods + gold.SumOfPlus10Mods,
                SumOfPlus15Mods = grey.SumOfPlus15Mods + green.SumOfPlus15Mods + blue.SumOfPlus15Mods + purple.SumOfPlus15Mods + gold.SumOfPlus15Mods,
                SumOfPlus20Mods = grey.SumOfPlus20Mods + green.SumOfPlus20Mods + blue.SumOfPlus20Mods + purple.SumOfPlus20Mods + gold.SumOfPlus20Mods,
                SumOfPlus25Mods = grey.SumOfPlus25Mods + green.SumOfPlus25Mods + blue.SumOfPlus25Mods + purple.SumOfPlus25Mods + gold.SumOfPlus25Mods,
            };
        }


        private StrategyResult EvaluateModsByGrade(ModGrade grade)
        {
            var filteredSpeedResults = GetFilteredSpeedResults(grade);

            var plus10Mods = filteredSpeedResults.FindAll(f => f.Speed >= 10 && f.Speed < 15);
            var plus15Mods = filteredSpeedResults.FindAll(f => f.Speed >= 15 && f.Speed < 20);
            var plus20Mods = filteredSpeedResults.FindAll(f => f.Speed >= 20 && f.Speed < 25);
            var plus25Mods = filteredSpeedResults.FindAll(f => f.Speed >= 25 && f.Speed < 30);

            var gradeProbability = grade switch
            {
                ModGrade.Grey => InitialModQuality.Grey5DotShare,
                ModGrade.Green => InitialModQuality.Green5DotShare,
                ModGrade.Blue => InitialModQuality.Blue5DotShare,
                ModGrade.Purple => InitialModQuality.Purple5DotShare,
                ModGrade.Gold => InitialModQuality.Gold5DotShare,
                _ => throw new NotImplementedException(),
            };

            ModsSold += ModsSoldTemp - ModsSold;
            ModsSoldTemp = 0;

            //todo: Adjust modCount when removing Combination!!!
            return new StrategyResult
            {
                PassedDays = StrategyDTO.Days,
                SumOfPlus10Mods = plus10Mods.Sum(m => m.ModCount) * gradeProbability,
                SumOfPlus15Mods = plus15Mods.Sum(m => m.ModCount) * gradeProbability,
                SumOfPlus20Mods = plus20Mods.Sum(m => m.ModCount) * gradeProbability,
                SumOfPlus25Mods = plus25Mods.Sum(m => m.ModCount) * gradeProbability,
            };

        }

        private List<SpeedResult> GetFilteredSpeedResults(ModGrade grade)
        {
            var speedResults = new List<SpeedResult>(SpeedResults);

            foreach (var speedResult in speedResults)
            {
                var combinationsToRemove = new List<Combination>();
                EvaluateCombinations(speedResult, combinationsToRemove, grade);
                var removed = RemoveCombinations(speedResult, combinationsToRemove);
                speedResult.ModCount -= removed;
            }

            return speedResults;
        }

        private void EvaluateCombinations(SpeedResult speedResult, List<Combination> combinationsToRemove, ModGrade grade)
        {
            foreach (var combination in speedResult.PossibleCombinations)
            {
                switch (grade)
                {
                    case ModGrade.Grey:
                        if (StrategyDTO.GreyThreshold > combination.Mod.InitialSpeed
                            || StrategyDTO.GreenThreshold > combination.Mod.GreenSpeed
                            || StrategyDTO.BlueThreshold > combination.Mod.BlueSpeed
                            || StrategyDTO.PurpleThreshold > combination.Mod.PurpleSpeed)
                        {
                            combinationsToRemove.Add(combination);
                        }
                        break;

                    case ModGrade.Green:
                        if (StrategyDTO.GreenThreshold > combination.Mod.GreenSpeed
                            || StrategyDTO.BlueThreshold > combination.Mod.BlueSpeed
                            || StrategyDTO.PurpleThreshold > combination.Mod.PurpleSpeed)
                        {
                            combinationsToRemove.Add(combination);
                        }
                        break;

                    case ModGrade.Blue:
                        if (StrategyDTO.BlueThreshold > combination.Mod.BlueSpeed
                            || StrategyDTO.PurpleThreshold > combination.Mod.PurpleSpeed)
                        {
                            combinationsToRemove.Add(combination);
                        }
                        break;

                    case ModGrade.Purple:
                        if (StrategyDTO.PurpleThreshold > combination.Mod.PurpleSpeed)
                        {
                            combinationsToRemove.Add(combination);
                        }
                        break;

                    case ModGrade.Gold:
                        break;
                };
            }
        }

        private decimal RemoveCombinations(SpeedResult speedResult, List<Combination> combinationsToRemove)
        {
            var removed = 0M;

            foreach (var combinationToRemove in combinationsToRemove)
            {
                speedResult.PossibleCombinations.Remove(combinationToRemove);

                //Debug
                var percentageShare = combinationToRemove.Probability() / speedResult.Probability;

                removed += speedResult.ModCount * percentageShare;
            }

            return removed;
        }
    }
}
