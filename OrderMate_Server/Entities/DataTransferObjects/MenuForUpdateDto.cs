using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class MenuForUpdateDto
    {
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public DateTime MenuDateCreated { get; set; }
        public TimeSpan? MenuTimeActiveFrom { get; set; }
        public TimeSpan? MenuTimeActiveTo { get; set; }
        public int? RestaurantIdFk { get; set; }
    }
}
