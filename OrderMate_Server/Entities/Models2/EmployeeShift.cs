using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class EmployeeShift
    {
        public int ShiftIdFk { get; set; }
        public int EmployeeIdFk { get; set; }

        public virtual Employee EmployeeIdFkNavigation { get; set; }
        public virtual Shift ShiftIdFkNavigation { get; set; }
    }
}
