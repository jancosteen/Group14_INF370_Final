using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class MenuItemPrice
    {
        public int MenuItemPriceId { get; set; }
        public double MenuItemPrice1 { get; set; }
        public DateTime MenuItemDateUpdated { get; set; }
        public int? MenuItemIdFk { get; set; }

        public virtual MenuItem MenuItemIdFkNavigation { get; set; }
    }
}
