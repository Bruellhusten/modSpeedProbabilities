using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries.Domain
{
    public class InitialSpeed
    {
        public int Speed { get; }
        public decimal Probability { get; }
        public InitialSpeed(int speed)
        {
            Speed = speed;
            switch (speed)
            {
                case 3:
                    Probability = 0.3268M;
                    break;
                case 4:
                    Probability = 0.3487M;
                    break;
                case 5:
                    Probability = 0.3245M;
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
