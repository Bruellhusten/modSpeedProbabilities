using System;
using System.Collections.Generic;
using System.Linq;

namespace generateTries
{
    class Program
    {
        public static List<SpeedResults> ResultList { get; set; }
        private const int TOP_SPEED = 29;
        private static readonly List<int> initialSpeeds = new List<int> { 3, 4, 5, };
        private static readonly List<int> slicingSpeeds = new List<int> { 3, 4, 5, 6, };

        static void Main(string[] args)
        {
            var list = PopulateSpeedResults(15);
            Console.WriteLine("check");
        }

        private static List<SpeedResults> PopulateSpeedResults(int lowerBorder)
        {
            List<SpeedResults> results = new List<SpeedResults>();

            if (lowerBorder <= TOP_SPEED)
            {
                for (int i = TOP_SPEED; i >= lowerBorder; i-- )
                {
                    var possibleCombinations = GeneratePossibleCombinations(i);
                    results.Add(new SpeedResults
                    {
                        Result = i,
                        PossibleCombinations = possibleCombinations,
                        Probability = possibleCombinations.Sum(x => x.Probability()),
                    });
                }
            }
            return results;
        }

        private static List<Combination> GeneratePossibleCombinations(int targetSpeed)
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
                                  });
            return combinations;
        }
    }
}
