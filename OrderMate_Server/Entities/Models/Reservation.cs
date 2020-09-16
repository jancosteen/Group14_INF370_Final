using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            ReservationRestaurant = new HashSet<ReservationRestaurant>();
            Seating = new HashSet<Seating>();
        }

        public int ReservationId { get; set; }
        public DateTime ReservationDateCreated { get; set; }
        public DateTime ReservationDateReserved { get; set; }
        public int ReservationPartyQty { get; set; }
        public string? UserIdFk { get; set; }
        public int? ReservationStatusIdFk { get; set; }
        public int ReservationNumberOfBills { get; set; }

        public virtual ReservationStatus ReservationStatusIdFkNavigation { get; set; }
        public virtual User UserIdFkNavigation { get; set; }
        public virtual ICollection<ReservationRestaurant> ReservationRestaurant { get; set; }
        public virtual ICollection<Seating> Seating { get; set; }
    }
}
