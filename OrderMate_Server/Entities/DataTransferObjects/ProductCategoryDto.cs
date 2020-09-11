using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProductCategoryDto
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategory1 { get; set; }

        //public virtual ICollection<ProductDto> Product { get; set; }
    }
}
