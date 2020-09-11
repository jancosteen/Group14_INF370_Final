using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Order_LineDetailsDto
    {
        public int OrderLineId { get; set; }
        public int ItemQty { get; set; }
        public string ItemComments { get; set; }
        public int? SpecialIdFk { get; set; }
        public int? MenuItemIdFk { get; set; }
        public int? OrderIdFk { get; set; }
        public int? EmployeeIdFk { get; set; }

        public virtual EmployeeDto EmployeeIdFkNavigation { get; set; }
        public virtual MenuItemDto MenuItemIdFkNavigation { get; set; }
        public virtual OrderDto OrderIdFkNavigation { get; set; }
        public virtual SpecialDto SpecialIdFkNavigation { get; set; }
    }
}
