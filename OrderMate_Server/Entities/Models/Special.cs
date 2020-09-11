using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Special
    {
        public Special()
        {
            MenuItemSpecial = new HashSet<MenuItemSpecial>();
            OrderLine = new HashSet<OrderLine>();
            SpecialPrice = new HashSet<SpecialPrice>();
        }

        public int SpecialId { get; set; }
        public DateTime SpecialStartDate { get; set; }
        public DateTime SpecialEndDate { get; set; }
        public string SpecialName { get; set; }
        public string SpecialDescription { get; set; }

        public virtual ICollection<MenuItemSpecial> MenuItemSpecial { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
        public virtual ICollection<SpecialPrice> SpecialPrice { get; set; }
    }
}
