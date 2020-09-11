using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Order_StatusDetailsDto
    {
        public int OrderStatusId { get; set; }
        public string OrderStatus1 { get; set; }
        public int? OrderIdFk { get; set; }

        public virtual OrderDto OrderIdFkNavigation { get; set; }
    }
}
