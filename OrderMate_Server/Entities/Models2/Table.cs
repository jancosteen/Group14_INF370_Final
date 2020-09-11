using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class Table
    {
        public Table()
        {
            RestaurantTable = new HashSet<RestaurantTable>();
        }

        public int TableId { get; set; }
        public int TableNr { get; set; }
        public int TableSeatQty { get; set; }

        public virtual ICollection<RestaurantTable> RestaurantTable { get; set; }
    }
}
