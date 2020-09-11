using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class WriteOffReason
    {
        public int WriteOffReasonId { get; set; }
        public string WriteOffReason1 { get; set; }
        public int WrittenOffStockIdFkFk { get; set; }
        public int ProductIdFkFk { get; set; }

        public virtual ProductWrittenOff ProductWrittenOff { get; set; }
    }
}
