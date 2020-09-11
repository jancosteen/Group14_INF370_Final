using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class EmployeeShiftDetailsDto
    {
        public int ShiftIdFk { get; set; }
        public int EmployeeIdFk { get; set; }

        public virtual EmployeeDto EmployeeIdFkNavigation { get; set; }
        public virtual ShiftDto ShiftIdFkNavigation { get; set; }
    }
}
