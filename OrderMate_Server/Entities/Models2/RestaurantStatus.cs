using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class RestaurantStatus
    {
        public RestaurantStatus()
        {
            Restaurant = new HashSet<Restaurant>();
        }

        public int RestaurantStatusId { get; set; }
        public string RestaurantStatus1 { get; set; }
        public int? RestaurantIdFk { get; set; }

        public virtual ICollection<Restaurant> Restaurant { get; set; }
    }
}
