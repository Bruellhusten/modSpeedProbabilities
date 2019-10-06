using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries.Domain
{
    public class InitialSpeed
    {
        private const decimal SPEED_3_CHANCE = 0.3268M;
        private const decimal SPEED_4_CHANCE = 0.3487M;
        private const decimal SPEED_5_CHANCE = 0.3245M;

        public int Speed { get; }
        public decimal Probability { get; }
        public InitialSpeed(int speed)
        {
            Speed = speed;
            switch (speed)
            {
                case 3:
                    Probability = SPEED_3_CHANCE;
                    break;
                case 4:
                    Probability = SPEED_4_CHANCE;
                    break;
                case 5:
                    Probability = SPEED_5_CHANCE;
                    break;
                case 6:
                    Probability = 0M;
                    break;
                default:
                    break;
            }
        }
    }
}
