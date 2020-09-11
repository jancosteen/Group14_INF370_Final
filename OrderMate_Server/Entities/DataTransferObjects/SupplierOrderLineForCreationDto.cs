using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SupplierOrderLineForCreationDto
    {
        public int ProductIdFk { get; set; }
        public int SupplierOrderIdFk { get; set; }
        public int DeliveryLeadTime { get; set; }
        public double ProductStandardPrice { get; set; }
        public double DiscountAgreement { get; set; }
        public int OrderedQty { get; set; }
    }
}
