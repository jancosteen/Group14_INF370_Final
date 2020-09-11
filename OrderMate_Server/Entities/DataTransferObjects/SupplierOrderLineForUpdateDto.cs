using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SupplierOrderLineForUpdateDto
    {
        public int DeliveryLeadTime { get; set; }
        public double ProductStandardPrice { get; set; }
        public double DiscountAgreement { get; set; }
        public int OrderedQty { get; set; }
    }
}
