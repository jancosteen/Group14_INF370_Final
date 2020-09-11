using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class RestaurantTable
    {
        public RestaurantTable()
        {
            RestaurantTableStatus = new HashSet<RestaurantTableStatus>();
            TableSeating = new HashSet<TableSeating>();
        }

        public int TableIdFk { get; set; }
        public int RestaurantIdFk { get; set; }

        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
        public virtual Table TableIdFkNavigation { get; set; }
        public virtual ICollection<RestaurantTableStatus> RestaurantTableStatus { get; set; }
        public virtual ICollection<TableSeating> TableSeating { get; set; }
    }
}
