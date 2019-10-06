using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries.Domain
{
    public class SlicingIncrease
    {
        public int Increase { get; }
        public decimal Probability { get; }
        private const decimal SLICING_SUCCESS_CHANCE = 0.25M;
        private const decimal SLICING_FAIL_CHANCE = 0.75M;
        private const decimal PLUS_3_INCREASE_CHANCE = 0.2292M;
        private const decimal PLUS_4_INCREASE_CHANCE = 0.3167M;
        private const decimal PLUS_5_INCREASE_CHANCE = 0.3M;
        private const decimal PLUS_6_INCREASE_CHANCE = 0.1542M;

        public SlicingIncrease(int increase)
        {
            Increase = increase;
            switch (increase)
            {
                case 0:
                    Probability = SLICING_FAIL_CHANCE;
                    break;
                case 3:
                    Probability = PLUS_3_INCREASE_CHANCE * SLICING_SUCCESS_CHANCE;
                    break;
                case 4:
                    Probability = PLUS_4_INCREASE_CHANCE * SLICING_SUCCESS_CHANCE;
                    break;
                case 5:
                    Probability = PLUS_5_INCREASE_CHANCE * SLICING_SUCCESS_CHANCE;
                    break;
                case 6:
                    Probability = PLUS_6_INCREASE_CHANCE * SLICING_SUCCESS_CHANCE;
                    break;
                default:
                    break;
            }
        }
    }
}
