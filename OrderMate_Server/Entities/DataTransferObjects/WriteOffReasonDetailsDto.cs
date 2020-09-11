using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class WriteOffReasonDetailsDto
    {
        public int WriteOffReasonId { get; set; }
        public string WriteOffReason1 { get; set; }
        public int WrittenOffStockIdFkFk { get; set; }
        public int ProductIdFkFk { get; set; }

        public virtual ProductWrittenOffDto ProductWrittenOff { get; set; }
    }
}
