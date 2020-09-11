using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProductWrittenOffForCreationDto
    {
        public int WrittenOffStockIdFk { get; set; }
        public int ProductIdFk { get; set; }
        public int WrittenOffQty { get; set; }
        public int? EmployeeIdFk { get; set; }

    }
}
