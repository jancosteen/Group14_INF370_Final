using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductReorderLevel { get; set; }
        public int ProductOnHand { get; set; }
        public int? ProductTypeIdFk { get; set; }
        public int? ProductCategoryIdFk { get; set; }
        public int? ProductReorderFreqIdFk { get; set; }
    }
}
