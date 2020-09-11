using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class AttendanceSheetForCreationDto
    {
        public DateTime ClockInDateTime { get; set; }
        public DateTime ClockOutDateTime { get; set; }
        public int? EmployeeIdFk { get; set; }
    }
}
