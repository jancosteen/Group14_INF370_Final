using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeIdNumber { get; set; }
        public int? RestaurantIdFk { get; set; }
    }

}
