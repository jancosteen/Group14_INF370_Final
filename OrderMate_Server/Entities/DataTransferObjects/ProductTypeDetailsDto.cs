using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProductTypeDetailsDto
    {
        public int ProductTypeId { get; set; }
        public string ProductType1 { get; set; }

        public virtual ICollection<ProductDto> Product { get; set; }
    }
}
