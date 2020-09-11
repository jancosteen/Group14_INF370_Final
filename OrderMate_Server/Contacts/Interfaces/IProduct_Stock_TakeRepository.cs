using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IProduct_Stock_TakeRepository: IRepositoryBase<ProductStockTake>
    {
        IEnumerable<ProductStockTake> StockTakeByProduct(int productId);
        IEnumerable<ProductStockTake> GetAllProductStockTakes();
        ProductStockTake GetProductStockTakeById(int prodId, int stockTakeId);
        ProductStockTake GetProductStockTakeDetails(int prodId, int stockTakeId);
        void CreateProdStockTake(ProductStockTake prodStockTake);
        void UpdateProdStockTake(ProductStockTake prodStockTake);
        void DeleteProdStockTake(ProductStockTake prodStockTake);

    }
}
