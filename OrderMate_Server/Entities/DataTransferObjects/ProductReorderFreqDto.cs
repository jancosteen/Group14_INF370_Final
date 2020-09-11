using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProductReorderFreqDto
    {
        public int ProductReorderFreqId { get; set; }
        public string ProductReorderFreq1 { get; set; }

        //public virtual ICollection<ProductDto> Product { get; set; }
    }
}
