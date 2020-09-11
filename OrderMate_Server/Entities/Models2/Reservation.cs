using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class Reservation
    {
        public Reservation()
        {
            TableSeating = new HashSet<TableSeating>();
        }

        public int ReservationId { get; set; }
        public DateTime ReservationDateCreated { get; set; }
        public DateTime ReservationDateReserved { get; set; }
        public int ReservationPartyQty { get; set; }
        public int? UserIdFk { get; set; }
        public int? ReservationStatusIdFk { get; set; }

        public virtual ReservationStatus ReservationStatusIdFkNavigation { get; set; }
        public virtual User UserIdFkNavigation { get; set; }
        public virtual ICollection<TableSeating> TableSeating { get; set; }
    }
}
