using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries.Domain
{
    public class SlicingCosts
    {
        public int ToGreen { get; }
        public int ToBlue { get; }
        public int ToPurple { get; }
        public int ToGold { get; }
        public SlicingCosts()
        {
            ToGreen = 10;
            ToBlue = 20;
            ToPurple = 35;
            ToGold = 50;
        }
    }
}
