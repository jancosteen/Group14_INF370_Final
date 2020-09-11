using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class MenuItem_ItemTypeDetailsDto
    {
        public int MenuItemIdFk { get; set; }
        public int MenuItemTypeIdFk { get; set; }

        public virtual MenuItemDto MenuItemIdFkNavigation { get; set; }
        public virtual MenuItemTypeDto MenuItemTypeIdFkNavigation { get; set; }
    }
}
