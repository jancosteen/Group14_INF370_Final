using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class ItemTypeMenuMenuItem
    {
        public int MenuItemIdFk { get; set; }
        public int MenuItemTypeIdFk { get; set; }

        public virtual MenuItem MenuItemIdFkNavigation { get; set; }
        public virtual MenuItemType MenuItemTypeIdFkNavigation { get; set; }
    }
}
