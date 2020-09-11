using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class OrderDetailsDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDateCreated { get; set; }
        public DateTime? OrderDateCompleted { get; set; }
        public int? QrCodeSeatingIdFk { get; set; }
        public int? orderStatus1 { get; set; }

        public virtual ICollection<Order_LineDto> OrderLine { get; set; }
        public virtual ICollection<Order_StatusDto> OrderStatus { get; set; }
        public virtual ICollection<QrCode_SeatingDto> QrCodeSeating { get; set; }
    }
}
