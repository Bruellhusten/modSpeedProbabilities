using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries
{
    public class SpeedResults
    {
        public int Speed { get; set; }
        public decimal Probability { get; set; }
        public List<Combination> PossibleCombinations { get; set; }
        public SpeedResults()
        {
            //PopulateSpeedResult();
        }

    }
}
