using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries.Domain
{
    public class SlicingIncrease
    {
        public int Increase { get; }
        public decimal Probability { get; }
        private const decimal SLICING_SUCCESS = 0.25M;
        private const decimal SLICING_FAIL = 0.75M;
        public SlicingIncrease(int increase)
        {
            Increase = increase;
            switch (increase)
            {
                case 0:
                    Probability = SLICING_FAIL;
                    break;
                case 3:
                    Probability = 0.2292M * SLICING_SUCCESS;
                    break;
                case 4:
                    Probability = 0.3167M * SLICING_SUCCESS;
                    break;
                case 5:
                    Probability = 0.3M * SLICING_SUCCESS;
                    break;
                case 6:
                    Probability = 0.1542M * SLICING_SUCCESS;
                    break;
                default:
                    break;
            }
        }
    }
}
