using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries.Domain
{
    public static class InitialModQuality
    {
        public static decimal Trash { get; set; } = 0.206M;
        public static decimal Grey { get; } = 0.5053M;
        public static decimal Grey5DotShare => 1 / GradeFiveChance() * Grey;
        public static decimal Green { get; } = 0.1474M;
        public static decimal Green5DotShare => 1 / GradeFiveChance() * Green;
        public static decimal Blue { get; } = 0.0917M;
        public static decimal Blue5DotShare => 1 / GradeFiveChance() * Blue;
        public static decimal Purple { get; } = 0.0271M;
        public static decimal Purple5DotShare => 1 / GradeFiveChance() * Purple;
        public static decimal Gold { get; } = 0.0226M;
        public static decimal Gold5DotShare => 1 / GradeFiveChance() * Gold;


        internal static decimal GreenOrBetter()
        {
            return Green + Blue + Purple + Gold;
        }

        internal static decimal BlueOrBetter()
        {
            return Blue + Purple + Gold;
        }

        internal static decimal PurpleOrBetter()
        {
            return Purple + Gold;
        }

        public static decimal GradeFiveChance() => 1 - Trash;
    }
}
