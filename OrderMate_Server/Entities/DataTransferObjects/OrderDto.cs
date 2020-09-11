using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDateCreated { get; set; }
        public DateTime? OrderDateCompleted { get; set; }
        public int? QrCodeSeatingIdFk { get; set; }
        //public int? orderStatus { get; set; }

        /*public virtual ICollection<OrderLine> OrderLine { get; set; }
        public virtual ICollection<OrderStatus> OrderStatus { get; set; }
        public virtual ICollection<QrCodeSeating> QrCodeSeating { get; set; }*/
    }
}
