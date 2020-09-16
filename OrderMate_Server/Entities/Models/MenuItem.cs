using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            ItemTypeMenuMenuItem = new HashSet<ItemTypeMenuMenuItem>();
            MenuItemAllergy = new HashSet<MenuItemAllergy>();
            MenuItemSpecial = new HashSet<MenuItemSpecial>();
            MenuRestaurant = new HashSet<MenuRestaurant>();
            OrderLine = new HashSet<OrderLine>();
        }

        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public int? MenuItemCategoryIdFk { get; set; }
        public int? MenuItemPriceIdFk { get; set; }

        public virtual MenuItemCategory MenuItemCategoryIdFkNavigation { get; set; }
        public virtual MenuItemPrice MenuItemPriceIdFkNavigation { get; set; }
        public virtual ICollection<ItemTypeMenuMenuItem> ItemTypeMenuMenuItem { get; set; }
        public virtual ICollection<MenuItemAllergy> MenuItemAllergy { get; set; }
        public virtual ICollection<MenuItemSpecial> MenuItemSpecial { get; set; }
        public virtual ICollection<MenuRestaurant> MenuRestaurant { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
