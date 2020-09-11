using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ReservationStatusDetailsDto
    {
        public int ReservationStatusId { get; set; }
        public string ReservationStatus1 { get; set; }

        public virtual ICollection<ReservationDto> Reservation { get; set; }
    }
}
