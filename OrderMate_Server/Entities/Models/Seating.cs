using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Seating
    {
        public Seating()
        {
            QrCodeSeating = new HashSet<QrCodeSeating>();
        }

        public int SeatingId { get; set; }
        public DateTime SeatingDate { get; set; }
        public TimeSpan SeatingTime { get; set; }
        public int? ReservationIdFk { get; set; }

        public virtual Reservation ReservationIdFkNavigation { get; set; }
        public virtual ICollection<QrCodeSeating> QrCodeSeating { get; set; }
    }
}
