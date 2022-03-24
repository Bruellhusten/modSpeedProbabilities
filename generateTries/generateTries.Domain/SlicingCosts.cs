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
        public int AverageSlicingCosts { get; set; }
        public StrategyDTO Strategy { get; set; }

        public SlicingCosts(ModGrade grade)
        {
            switch (grade)
            {
                case ModGrade.Grey:
                    ToGreen = 10;
                    ToBlue = 20;
                    ToPurple = 35;
                    ToGold = 50;
                    break;
                case ModGrade.Green:
                    ToGreen = 0;
                    ToBlue = 20;
                    ToPurple = 35;
                    ToGold = 50;
                    break;
                case ModGrade.Blue:
                    ToGreen = 0;
                    ToBlue = 0;
                    ToPurple = 35;
                    ToGold = 50;
                    break;
                case ModGrade.Purple:
                    ToGreen = 0;
                    ToBlue = 0;
                    ToPurple = 0;
                    ToGold = 50;
                    break;
                case ModGrade.Gold:
                    ToGreen = 0;
                    ToBlue = 0;
                    ToPurple = 0;
                    ToGold = 0;
                    break;
            }
        }
    }
}
