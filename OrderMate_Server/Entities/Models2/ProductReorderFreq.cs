using System;
using System.Collections.Generic;

namespace Entities.Models2
{
    public partial class ProductReorderFreq
    {
        public ProductReorderFreq()
        {
            Product = new HashSet<Product>();
        }

        public int ProductReorderFreqId { get; set; }
        public string ProductReorderFreq1 { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
