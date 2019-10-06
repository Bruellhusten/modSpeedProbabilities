﻿using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries.Domain
{
    public class Combination
    {
        public InitialSpeed Init { get; set; }
        public SlicingIncrease ToGreen { get; set; }
        public SlicingIncrease ToBlue { get; set; }
        public SlicingIncrease ToPurple { get; set; }
        public SlicingIncrease ToGold { get; set; }
        public Mod Mod { get; set; }

        public int Speed()
        {
            return Mod.GoldSpeed;
        }

        public decimal Probability()
        {
            return Init.Probability * ToGreen.Probability * ToBlue.Probability * ToPurple.Probability * ToGold.Probability;
        }
    }
}
