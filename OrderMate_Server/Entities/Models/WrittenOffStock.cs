using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class WrittenOffStock
    {
        public WrittenOffStock()
        {
            ProductWrittenOff = new HashSet<ProductWrittenOff>();
        }

        public int WrittenOfStockId { get; set; }
        public DateTime WrittenOfStockDate { get; set; }

        public virtual ICollection<ProductWrittenOff> ProductWrittenOff { get; set; }
    }
}
