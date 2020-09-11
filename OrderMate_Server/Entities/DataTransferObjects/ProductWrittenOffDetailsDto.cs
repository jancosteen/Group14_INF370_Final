using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProductWrittenOffDetailsDto
    {
        public int WrittenOffStockIdFk { get; set; }
        public int ProductIdFk { get; set; }
        public int WrittenOffQty { get; set; }
        public int? EmployeeIdFk { get; set; }

        public virtual EmployeeDto EmployeeIdFkNavigation { get; set; }
        public virtual ProductDto ProductIdFkNavigation { get; set; }
        public virtual WrittenOffStockDto WrittenOffStockIdFkNavigation { get; set; }
        public virtual ICollection<WriteOffReasonDto> WriteOffReason { get; set; }
    }
}
