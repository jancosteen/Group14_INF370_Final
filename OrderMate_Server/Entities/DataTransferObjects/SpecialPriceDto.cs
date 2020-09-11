using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SpecialPriceDto
    {
        public int SpecialPriceId { get; set; }
        public double SpecialPrice1 { get; set; }
        public DateTime SpecialPriceDateUpdated { get; set; }
        public int? SpecialIdFk { get; set; }
    }
}
