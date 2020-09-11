using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProductCategoryDetailsDto
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategory1 { get; set; }

        public virtual ICollection<ProductDto> Product { get; set; }
    }
}
