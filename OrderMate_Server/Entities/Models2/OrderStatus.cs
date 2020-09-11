using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class OrderStatus
    {
        public int OrderStatusId { get; set; }
        public string OrderStatus1 { get; set; }
        public int? OrderIdFk { get; set; }

        public virtual Order OrderIdFkNavigation { get; set; }
    }
}
