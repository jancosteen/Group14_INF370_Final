using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class EmployeeShift
    {
        public int ShiftIdFk { get; set; }
        public int EmployeeIdFk { get; set; }
        public int EmployeeShiftId { get; set; }

        public virtual Employee EmployeeIdFkNavigation { get; set; }
        public virtual Shift ShiftIdFkNavigation { get; set; }
    }
}
