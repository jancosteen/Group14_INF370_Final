using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class MenuItemCategory
    {
        public MenuItemCategory()
        {
            MenuItem = new HashSet<MenuItem>();
        }

        public int MenuItemCategoryId { get; set; }
        public string MenuItemCategory1 { get; set; }

        public virtual ICollection<MenuItem> MenuItem { get; set; }
    }
}
