using generateTries.Domain;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace generateTries.Application
{
    class Program
    {
        public static List<SpeedResult> ResultList { get; set; }
        private const int TOP_SPEED = 29;
        private static readonly List<int> initialSpeeds = new List<int> { 3, 4, 5, };
        private static readonly List<int> slicingSpeeds = new List<int> { 0, 3, 4, 5, 6, };

        public static void Main(string[] args)
        {
            var list = PopulateSpeedResults(0);
            ExcelFileWriter.ExportToExcel(list);
            Console.WriteLine("check");
        }

        public static decimal CalculateChance(int speed)
        {
            var list = PopulateSpeedResults(speed);
            return list.Where(e => e.Speed.Equals(speed))
                           .FirstOrDefault()
                           .Probability;
        }

        public static decimal CalculateChances(int lowerBorder)
        {
            var list = PopulateSpeedResults(lowerBorder);
            return list.Sum(e => e.Probability);
        }

        private static List<SpeedResult> PopulateSpeedResults(int lowerBorder)
        {
            List<SpeedResult> results = new List<SpeedResult>();

            if (lowerBorder <= TOP_SPEED)
            {
                for (int i = TOP_SPEED; i >= lowerBorder; i--)
                {
                    var possibleCombinations = GeneratePossibleCombinations(i);
                    results.Add(new SpeedResult
                    {
                        Speed = i,
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
