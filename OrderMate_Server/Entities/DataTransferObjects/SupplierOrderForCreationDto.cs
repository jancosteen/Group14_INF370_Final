using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class SupplierOrderForCreationDto
    {
        public DateTime SupplierOrderDate { get; set; }
        public int? SupplierIdFk { get; set; }
    }
}
