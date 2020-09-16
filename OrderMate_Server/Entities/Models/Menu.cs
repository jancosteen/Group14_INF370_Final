using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Menu
    {
        public Menu()
        {
            MenuRestaurant = new HashSet<MenuRestaurant>();
        }

        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public DateTime MenuDateCreated { get; set; }
        public TimeSpan? MenuTimeActiveFrom { get; set; }
        public TimeSpan? MenuTimeActiveTo { get; set; }

        public virtual ICollection<MenuRestaurant> MenuRestaurant { get; set; }
    }
}
