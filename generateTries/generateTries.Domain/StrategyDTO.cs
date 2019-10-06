using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace generateTries.Domain
{
    public class StrategyDTO
    {
        [DefaultValue(4)]
        public int GreyThreshold { get; set; }
        [DefaultValue(8)]
        public int GreenThreshold { get; set; }
        [DefaultValue(13)]
        public int BlueThreshold { get; set; }
        [DefaultValue(13)]
        public int PurpleThreshold { get; set; }
        [DefaultValue(240)]
        public int DailyShipEnergy { get; set; }
        [DefaultValue(100)]
        public int DailySlicingCrystal { get; set; }

    }
}
