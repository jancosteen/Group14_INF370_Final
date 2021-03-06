﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class AttendanceSheetDetailsDto
    {
        public int AttendanceSheetId { get; set; }
        public DateTime ClockInDateTime { get; set; }
        public DateTime ClockOutDateTime { get; set; }
        public int? EmployeeIdFk { get; set; }

        public virtual EmployeeDto EmployeeIdFkNavigation { get; set; }
    }
}
