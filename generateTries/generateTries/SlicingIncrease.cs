using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries
{
    public class SlicingIncrease
    {
        public int Increase { get; }
        public decimal Probability { get; }
        public SlicingIncrease(int increase)
        {
            Increase = increase;
            switch (increase)
            {
                case 3:
                    Probability = 0.2292M;
                    break;
                case 4:
                    Probability = 0.3167M;
                    break;
                case 5:
                    Probability = 0.3M;
                    break;
                case 6:
                    Probability = 0.1542M;
                    break;
                default:
                    break;
            }
        }
    }
}
