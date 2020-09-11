using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Reporting
{
    public class PeakHourReport
    {
        public int Week { get; set; }
        public string Day_Of_Week { get; set; }
        public int Hour_Of_Day { get; set; }
        public int Count { get; set; }
    }
}
