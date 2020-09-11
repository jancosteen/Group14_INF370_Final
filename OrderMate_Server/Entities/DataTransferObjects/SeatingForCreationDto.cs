using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SeatingForCreationDto
    {
        public DateTime SeatingDate { get; set; }
       // public string SeatingTime { get; set; }
        public int? ReservationIdFk { get; set; }
    }
}
