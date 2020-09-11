using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SeatingDto
    {
        public int SeatingId { get; set; }
        public DateTime SeatingDate { get; set; }
        public TimeSpan SeatingTime { get; set; }
        public int? ReservationIdFk { get; set; }
    }
}
