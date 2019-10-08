using System;
using System.Collections.Generic;
using System.Text;

namespace generateTries.Domain
{
    public class SlicingMaterial
    {
        public int SlicingMaterialCosts { get; set; }
        public int CrystalPerMaterial { get; set; }
        public decimal MaterialDropRate { get; set; }
        public decimal CrystalToEnergyEquivalent { get; set; }

        public SlicingMaterial()
        {
            SlicingMaterialCosts = 14;
            CrystalPerMaterial = 8;
            MaterialDropRate = 1.3M;
            CrystalToEnergyEquivalent = SlicingMaterialCosts * MaterialDropRate / CrystalPerMaterial;
        }

    }
}
