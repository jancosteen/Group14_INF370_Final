using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class AttendanceSheet
    {
        public int AttendanceSheetId { get; set; }
        public DateTime ClockInDateTime { get; set; }
        public DateTime ClockOutDateTime { get; set; }
        public int? EmployeeIdFk { get; set; }

        public virtual Employee EmployeeIdFkNavigation { get; set; }
    }
}
