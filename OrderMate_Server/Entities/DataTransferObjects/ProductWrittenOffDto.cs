using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProductWrittenOffDto
    {
        public int WrittenOffStockIdFk { get; set; }
        public int ProductIdFk { get; set; }
        public int WrittenOffQty { get; set; }
        public int? EmployeeIdFk { get; set; }

        //This is added to the details DTO
        //public virtual Employee EmployeeIdFkNavigation { get; set; }
        //public virtual Product ProductIdFkNavigation { get; set; }
        //public virtual WrittenOffStock WrittenOffStockIdFkNavigation { get; set; }
        //public virtual ICollection<WriteOffReason> WriteOffReason { get; set; }
    }
}
