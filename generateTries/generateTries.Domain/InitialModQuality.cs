using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries.Domain
{
    public class InitialModQuality
    {
        public decimal Trash { get; set; }
        public decimal Grey { get; }
        public decimal Green { get; }
        public decimal Blue { get; }
        public decimal Purple { get; }
        public decimal Gold { get; }

        public InitialModQuality()
        {
            Trash = 0.206M;
            Grey = 0.5053M;
            Green = 0.1474M;
            Blue = 0.0917M;
            Purple = 0.0271M;
            Gold = 0.0226M;
        }
    }
}
