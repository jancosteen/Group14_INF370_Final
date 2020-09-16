using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Order = new HashSet<Order>();
        }

        public int OrderStatusId { get; set; }
        public string OrderStatus1 { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
