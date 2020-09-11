using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class MenuDetailsDto
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public DateTime MenuDateCreated { get; set; }
        public TimeSpan? MenuTimeActiveFrom { get; set; }
        public TimeSpan? MenuTimeActiveTo { get; set; }
        public int? RestaurantIdFk { get; set; }

        public virtual RestaurantDto RestaurantIdFkNavigation { get; set; }
        public virtual ICollection<MenuItemDto> MenuItem { get; set; }
    }
}
