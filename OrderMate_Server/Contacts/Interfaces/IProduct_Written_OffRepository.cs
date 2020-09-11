using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IProduct_Written_OffRepository: IRepositoryBase<ProductWrittenOff>
    {
        IEnumerable<ProductWrittenOff> WrittenOffByProduct(int productId);
        IEnumerable<ProductWrittenOff> GetAllProductWrittenOffs();
        ProductWrittenOff GetProductWrittenOffById(int woStockId, int prodId);
        ProductWrittenOff GetProductWrittenOffDetails(int woStockId, int prodId);
        void CreateProductWrittenOff(ProductWrittenOff prdWO);
        void UpdateProductWrittenOff(ProductWrittenOff prdWO);
    }
}
