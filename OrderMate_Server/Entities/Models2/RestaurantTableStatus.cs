using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class RestaurantTableStatus
    {
        public int RestaurantTableStatusId { get; set; }
        public string RestaurantTableStatus1 { get; set; }
        public string RestaurantTableStatusDateUpdated { get; set; }
        public int? TableIdFkFk { get; set; }
        public int? RestaurantIdFkFk { get; set; }

        public virtual RestaurantTable RestaurantTable { get; set; }
    }
}
