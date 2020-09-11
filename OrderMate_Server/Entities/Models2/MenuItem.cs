using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            ItemTypeMenuMenuItem = new HashSet<ItemTypeMenuMenuItem>();
            MenuItemAllergy = new HashSet<MenuItemAllergy>();
            MenuItemPrice = new HashSet<MenuItemPrice>();
            MenuItemSpecial = new HashSet<MenuItemSpecial>();
            OrderLine = new HashSet<OrderLine>();
        }

        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public int? MenuIdFk { get; set; }
        public int? MenuItemCategoryIdFk { get; set; }

        public virtual Menu MenuIdFkNavigation { get; set; }
        public virtual MenuItemCategory MenuItemCategoryIdFkNavigation { get; set; }
        public virtual ICollection<ItemTypeMenuMenuItem> ItemTypeMenuMenuItem { get; set; }
        public virtual ICollection<MenuItemAllergy> MenuItemAllergy { get; set; }
        public virtual ICollection<MenuItemPrice> MenuItemPrice { get; set; }
        public virtual ICollection<MenuItemSpecial> MenuItemSpecial { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
