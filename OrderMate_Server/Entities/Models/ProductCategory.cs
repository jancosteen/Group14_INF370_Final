using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Product = new HashSet<Product>();
        }

        public int ProductCategoryId { get; set; }
        public string ProductCategory1 { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
