using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace generateTries.Application
{
    //ToDo: DI class
    public class Chances
    {
        public static decimal CalculateSingle(int speed)
        {
            var list = DataGenerator.PopulateSpeedResults(speed);
            return list.FirstOrDefault(e => e.Speed.Equals(speed))                           
                        .Probability;
        }

        public static decimal CalculateMany(int lowerBorder)
        {
            var list = DataGenerator.PopulateSpeedResults(lowerBorder);
            return list.Sum(e => e.Probability);
        }
    }
}
