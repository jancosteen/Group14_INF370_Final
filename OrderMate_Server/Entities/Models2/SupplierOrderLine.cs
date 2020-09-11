using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class SupplierOrderLine
    {
        public int ProductIdFk { get; set; }
        public int SupplierOrderIdFk { get; set; }
        public int DeliveryLeadTime { get; set; }
        public double ProductStandardPrice { get; set; }
        public double DiscountAgreement { get; set; }
        public int OrderedQty { get; set; }

        public virtual Product ProductIdFkNavigation { get; set; }
        public virtual SupplierOrder SupplierOrderIdFkNavigation { get; set; }
    }
}
