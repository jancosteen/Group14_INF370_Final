using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderLine = new HashSet<OrderLine>();
            QrCodeSeating = new HashSet<QrCodeSeating>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDateCreated { get; set; }
        public DateTime? OrderDateCompleted { get; set; }
        public int? QrCodeSeatingIdFk { get; set; }
        public int? OrderStatusIdFk { get; set; }

        public virtual OrderStatus OrderStatusIdFkNavigation { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
        public virtual ICollection<QrCodeSeating> QrCodeSeating { get; set; }
    }
}
