using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProductReorderFreqDetailsDto
    {
        public int ProductReorderFreqId { get; set; }
        public string ProductReorderFreq1 { get; set; }

        public virtual ICollection<ProductDto> Product { get; set; }
    }
}
