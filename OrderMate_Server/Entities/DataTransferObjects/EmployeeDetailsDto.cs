using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class EmployeeDetailsDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeIdNumber { get; set; }
        public int? RestaurantIdFk { get; set; }

        public virtual RestaurantDto RestaurantIdFkNavigation { get; set; }
        public virtual ICollection<AttendanceSheetDto> AttendanceSheet { get; set; }
        public virtual ICollection<EmployeeShiftDto> EmployeeShift { get; set; }
        public virtual ICollection<Order_LineDto> OrderLine { get; set; }
        public virtual ICollection<ProductStockTakeDto> ProductStockTake { get; set; }
        public virtual ICollection<ProductWrittenOffDto> ProductWrittenOff { get; set; }
        public virtual ICollection<UserDto> User { get; set; }
    }
}
