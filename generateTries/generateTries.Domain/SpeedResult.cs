using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace generateTries.Domain
{
    public class SpeedResult
    {
        public int Speed { get; set; }
        public decimal Probability { get; set; }
        public List<Combination> PossibleCombinations { get; set; }
        public decimal ModCount { get; set; }

    }
}
