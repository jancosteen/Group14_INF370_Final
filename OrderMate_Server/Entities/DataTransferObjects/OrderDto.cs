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
        public int? orderStatus1 { get; set; }
        public int? QrCodeSeatingIdFk { get; set; }
    }
}
