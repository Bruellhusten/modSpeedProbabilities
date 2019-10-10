using generateTries.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace generateTries.Application
{
    public class DataGenerator
    {
        private const int TOP_SPEED = 29;
        private static readonly List<int> initialSpeeds = new List<int> { 3, 4, 5, };
        private static readonly List<int> slicingSpeeds = new List<int> { 0, 3, 4, 5, 6, };

        public List<SpeedResult> PopulateSpeedResults(int lowerBorder)
        {
            var results = new List<SpeedResult>();

            if (lowerBorder <= TOP_SPEED)
            {
                for (int speed = TOP_SPEED; speed >= lowerBorder; speed--)
                {
                    GenerateResultLines(results, speed);
                }
            }
            return results;
        }

        public virtual List<Combination> GeneratePossibleCombinations(int targetSpeed)
        {
            var combinations = new List<Combination>();
            combinations.AddRange(from int greySpeed in initialSpeeds
                                  from int greenIncrease in slicingSpeeds
                                  from int blueIncrease in slicingSpeeds
                                  from int purpleIncrease in slicingSpeeds
                                  from int goldIncreases in slicingSpeeds
                                  where greySpeed + greenIncrease + blueIncrease + purpleIncrease + goldIncreases == targetSpeed
                                  select new Combination
                                  {
                                      Init = new InitialSpeed(greySpeed),
                                      ToGreen = new SlicingIncrease(greenIncrease),
                                      ToBlue = new SlicingIncrease(blueIncrease),
                                      ToPurple = new SlicingIncrease(purpleIncrease),
                                      ToGold = new SlicingIncrease(goldIncreases),
                                      Mod = new Mod
                                      {
                                          InitialSpeed = greySpeed,
                                          GreenSpeed = greySpeed + greenIncrease,
                                          BlueSpeed = greySpeed + greenIncrease + blueIncrease,
                                          PurpleSpeed = greySpeed + greenIncrease + blueIncrease + purpleIncrease,
                                          GoldSpeed = greySpeed + greenIncrease + blueIncrease + purpleIncrease + goldIncreases,
                                      }
                                  });
            return combinations;
        }

        public virtual void GenerateResultLines(List<SpeedResult> results, int speed)
        {
            var possibleCombinations = GeneratePossibleCombinations(speed);
            results.Add(new SpeedResult
            {
                Speed = speed,
                PossibleCombinations = possibleCombinations,
                Probability = possibleCombinations.Sum(x => x.Probability()),
            });
        }
    }
}
