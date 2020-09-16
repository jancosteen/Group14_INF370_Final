using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ReservationRestaurant
    {
        public int ReservationIdFk { get; set; }
        public int RestaurantIdFk { get; set; }
        public int ReservationRestaurantId { get; set; }

        public virtual Reservation ReservationIdFkNavigation { get; set; }
        public virtual Restaurant RestaurantIdFkNavigation { get; set; }
    }
}
