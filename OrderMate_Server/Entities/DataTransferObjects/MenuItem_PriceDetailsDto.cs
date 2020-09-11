using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class MenuItem_PriceDetailsDto
    {
        public int MenuItemPriceId { get; set; }
        public double MenuItemPrice1 { get; set; }
        public DateTime MenuItemDateUpdated { get; set; }
        public int? MenuItemIdFk { get; set; }

        public virtual MenuItemDto MenuItemIdFkNavigation { get; set; }
    }
}
