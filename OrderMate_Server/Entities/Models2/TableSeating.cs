using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class TableSeating
    {
        public int TableIdFkFk { get; set; }
        public int RestaurantIdFkFk { get; set; }
        public int UserIdFk { get; set; }
        public int? ReservationIdFk { get; set; }
        public int OrderIdFk { get; set; }
        public DateTime? TableSeatingDateTimeActiveFrom { get; set; }
        public DateTime? TableSeatingDateTimeActiveTo { get; set; }
        public int? UserCommentIdFk { get; set; }

        public virtual Order OrderIdFkNavigation { get; set; }
        public virtual Reservation ReservationIdFkNavigation { get; set; }
        public virtual RestaurantTable RestaurantTable { get; set; }
        public virtual UserComment UserCommentIdFkNavigation { get; set; }
        public virtual User UserIdFkNavigation { get; set; }
    }
}
