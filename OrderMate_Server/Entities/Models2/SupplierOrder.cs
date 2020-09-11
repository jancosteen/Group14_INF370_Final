using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class SupplierOrder
    {
        public SupplierOrder()
        {
            SupplierOrderLine = new HashSet<SupplierOrderLine>();
        }

        public int SupplierOrderId { get; set; }
        public DateTime SupplierOrderDate { get; set; }
        public int? SupplierIdFk { get; set; }

        public virtual Supplier SupplierIdFkNavigation { get; set; }
        public virtual ICollection<SupplierOrderLine> SupplierOrderLine { get; set; }
    }
}
