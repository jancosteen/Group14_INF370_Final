using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class Menu
    {
        public Menu()
        {
            MenuItem = new HashSet<MenuItem>();
        }

        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public DateTime MenuDateCreated { get; set; }
        public TimeSpan? MenuTimeActiveFrom { get; set; }
        public TimeSpan? MenuTimeActiveTo { get; set; }
        public int? RestaurantIdFk { get; set; }

        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        public virtual ICollection<MenuItem> MenuItem { get; set; }
    }
}
