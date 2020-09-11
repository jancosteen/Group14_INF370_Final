using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ProductDetailsDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductReorderLevel { get; set; }
        public int ProductOnHand { get; set; }
        public int? ProductTypeIdFk { get; set; }
        public int? ProductCategoryIdFk { get; set; }
        public int? ProductReorderFreqIdFk { get; set; }

        public virtual ProductCategoryDto ProductCategoryIdFkNavigation { get; set; }
        public virtual ProductReorderFreqDto ProductReorderFreqIdFkNavigation { get; set; }
        public virtual ProductTypeDto ProductTypeIdFkNavigation { get; set; }
        public virtual ICollection<ProductStockTakeDto> ProductStockTake { get; set; }
        public virtual ICollection<ProductWrittenOffDto> ProductWrittenOff { get; set; }
        public virtual ICollection<SupplierOrderLineDto> SupplierOrderLine { get; set; }
    }
}
