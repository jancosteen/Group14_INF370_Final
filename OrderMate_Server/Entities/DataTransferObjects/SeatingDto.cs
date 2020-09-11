using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SeatingDto
    {
        public int SeatingId { get; set; }
        public DateTime SeatingDate { get; set; }
        //public string? SeatingTime { get; set; }
        public int? Reservation_Id_Fk { get; set; }
    }
}
