using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class MenuItemType
    {
        public MenuItemType()
        {
            ItemTypeMenuMenuItem = new HashSet<ItemTypeMenuMenuItem>();
        }

        public int MenuItemTypeId { get; set; }
        public string MenuItemType1 { get; set; }

        public virtual ICollection<ItemTypeMenuMenuItem> ItemTypeMenuMenuItem { get; set; }
    }
}
