using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Product_Stock_TakeRepository: RepositoryBase<ProductStockTake>, IProduct_Stock_TakeRepository
    {
        public Product_Stock_TakeRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateProdStockTake(ProductStockTake prodStockTake)
        {
            Create(prodStockTake);
        }

        public void DeleteProdStockTake(ProductStockTake prodStockTake)
        {
            Delete(prodStockTake);
        }

        public IEnumerable<ProductStockTake> GetAllProductStockTakes()
        {
            return FindAll()
                .OrderBy(pst => pst.StockTakeIdFk)
                .ToList();
        }

        public ProductStockTake GetProductStockTakeById(int prodId, int stockTakeId)
        {
            return FindByCondition(pst => pst.ProductIdFk.Equals(prodId) && pst.StockTakeIdFk.Equals(stockTakeId))
                .FirstOrDefault();
        }

        public ProductStockTake GetProductStockTakeDetails(int prodId, int stockTakeId)
        {
            return FindByCondition(pst => pst.ProductIdFk.Equals(prodId) && pst.StockTakeIdFk.Equals(stockTakeId))
                
                .Include(prod => prod.ProductIdFkNavigation)
                .Include(st => st.StockTakeIdFkNavigation)
                .FirstOrDefault();
            //.Include(em => em.EmployeeIdFkNavigation)
        }

        public IEnumerable<ProductStockTake> StockTakeByProduct(int productId)
        {
            return FindByCondition(st => st.ProductIdFk.Equals(productId)).ToList();
        }

        public void UpdateProdStockTake(ProductStockTake prodStockTake)
        {
            Update(prodStockTake);
        }
    }
}
