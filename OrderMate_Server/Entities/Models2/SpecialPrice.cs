using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class SpecialPrice
    {
        public int SpecialPriceId { get; set; }
        public double SpecialPrice1 { get; set; }
        public DateTime SpecialPriceDateUpdated { get; set; }
        public int? SpecialIdFk { get; set; }

        public virtual Special SpecialIdFkNavigation { get; set; }
    }
}
