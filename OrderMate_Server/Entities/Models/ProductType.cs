using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Product = new HashSet<Product>();
        }

        public int ProductTypeId { get; set; }
        public string ProductType1 { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
