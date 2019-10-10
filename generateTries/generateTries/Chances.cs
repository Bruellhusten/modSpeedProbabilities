using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace generateTries.Application
{
    //ToDo: DI class
    public class Chances
    {
        public DataGenerator Generator { get; set; }
        public Chances()
        {
            Generator = new DataGenerator();
        }
        public decimal CalculateSingle(int speed)
        {
            
            var list = Generator.PopulateSpeedResults(speed);
            return list.FirstOrDefault(e => e.Speed.Equals(speed))                           
                        .Probability;
        }

        public decimal CalculateMany(int lowerBorder)
        {
            var list = Generator.PopulateSpeedResults(lowerBorder);
            return list.Sum(e => e.Probability);
        }
    }
}
