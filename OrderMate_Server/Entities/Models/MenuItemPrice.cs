using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class MenuItemPrice
    {
        public MenuItemPrice()
        {
            MenuItem = new HashSet<MenuItem>();
        }

        public int MenuItemPriceId { get; set; }
        public double MenuItemPrice1 { get; set; }
        public DateTime MenuItemDateUpdated { get; set; }

        public virtual ICollection<MenuItem> MenuItem { get; set; }
    }
}
