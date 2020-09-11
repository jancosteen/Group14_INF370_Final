using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class Order_LineForUpdateDto
    {
        public int ItemQty { get; set; }
        public string ItemComments { get; set; }
        public int? SpecialIdFk { get; set; }
        public int? MenuItemIdFk { get; set; }
        public int? OrderIdFk { get; set; }
        public int? EmployeeIdFk { get; set; }
    }
}
