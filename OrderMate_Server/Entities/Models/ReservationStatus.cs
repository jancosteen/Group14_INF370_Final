using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ReservationStatus
    {
        public ReservationStatus()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int ReservationStatusId { get; set; }
        public string ReservationStatus1 { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
