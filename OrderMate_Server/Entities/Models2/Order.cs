using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class Order
    {
        public Order()
        {
            OrderLine = new HashSet<OrderLine>();
            OrderStatus = new HashSet<OrderStatus>();
            TableSeating = new HashSet<TableSeating>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDateCreated { get; set; }
        public DateTime? OrderDateCompleted { get; set; }

        public virtual ICollection<OrderLine> OrderLine { get; set; }
        public virtual ICollection<OrderStatus> OrderStatus { get; set; }
        public virtual ICollection<TableSeating> TableSeating { get; set; }
    }
}
