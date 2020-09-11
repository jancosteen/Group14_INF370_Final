using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class WrittenOffStockDetailsDto
    {
        public int WrittenOfStockId { get; set; }
        public DateTime WrittenOfStockDate { get; set; }

        public virtual ICollection<ProductWrittenOffDto> ProductWrittenOff { get; set; }
    }
}
