using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class ProductWrittenOff
    {
        public ProductWrittenOff()
        {
            WriteOffReason = new HashSet<WriteOffReason>();
        }

        public int WrittenOffStockIdFk { get; set; }
        public int ProductIdFk { get; set; }
        public int WrittenOffQty { get; set; }
        public int? EmployeeIdFk { get; set; }

        public virtual Employee EmployeeIdFkNavigation { get; set; }
        public virtual Product ProductIdFkNavigation { get; set; }
        public virtual WrittenOffStock WrittenOffStockIdFkNavigation { get; set; }
        public virtual ICollection<WriteOffReason> WriteOffReason { get; set; }
    }
}
