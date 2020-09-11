using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SpecialDetailsDto
    {
        public int SpecialId { get; set; }
        public DateTime SpecialStartDate { get; set; }
        public DateTime SpecialEndDate { get; set; }
        public string SpecialName { get; set; }
        public string SpecialDescription { get; set; }

        public virtual ICollection<MenuItem_SpecialDto> MenuItemSpecial { get; set; }
        public virtual ICollection<Order_LineDto> OrderLine { get; set; }
        public virtual ICollection<SpecialPriceDto> SpecialPrice { get; set; }
    }
}
