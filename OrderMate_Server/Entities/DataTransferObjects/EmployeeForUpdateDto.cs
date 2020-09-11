using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class EmployeeForUpdateDto
    {
        public string EmployeeIdNumber { get; set; }
        public int? RestaurantIdFk { get; set; }
    }
}
