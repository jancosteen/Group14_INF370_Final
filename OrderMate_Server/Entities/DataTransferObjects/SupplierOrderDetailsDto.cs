using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SupplierOrderDetailsDto
    {
        public int SupplierOrderId { get; set; }
        public DateTime SupplierOrderDate { get; set; }
        public int? SupplierIdFk { get; set; }

        public virtual SupplierDto SupplierIdFkNavigation { get; set; }
        public virtual ICollection<SupplierOrderLineDto> SupplierOrderLine { get; set; }
    }
}
