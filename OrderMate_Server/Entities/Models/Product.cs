using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductStockTake = new HashSet<ProductStockTake>();
            ProductWrittenOff = new HashSet<ProductWrittenOff>();
            SupplierOrderLine = new HashSet<SupplierOrderLine>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductReorderLevel { get; set; }
        public int ProductOnHand { get; set; }
        public int? ProductTypeIdFk { get; set; }
        public int? ProductCategoryIdFk { get; set; }
        public int? ProductReorderFreqIdFk { get; set; }

        public virtual ProductCategory ProductCategoryIdFkNavigation { get; set; }
        public virtual ProductReorderFreq ProductReorderFreqIdFkNavigation { get; set; }
        public virtual ProductType ProductTypeIdFkNavigation { get; set; }
        public virtual ICollection<ProductStockTake> ProductStockTake { get; set; }
        public virtual ICollection<ProductWrittenOff> ProductWrittenOff { get; set; }
        public virtual ICollection<SupplierOrderLine> SupplierOrderLine { get; set; }
    }
}
