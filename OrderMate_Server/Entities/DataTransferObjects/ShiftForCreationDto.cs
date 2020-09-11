﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ShiftForCreationDto
    {
        public DateTime ShiftStartDateTime { get; set; }
        public DateTime ShiftEndDateTime { get; set; }
        public int ShiftCapacity { get; set; }
        public string ShiftName { get; set; }
        public int? ShiftStatusIdFk { get; set; }

    }
}
