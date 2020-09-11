using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Product_Written_OffRepository: RepositoryBase<ProductWrittenOff>, IProduct_Written_OffRepository
    {
        public Product_Written_OffRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateProductWrittenOff(ProductWrittenOff prdWO)
        {
            Create(prdWO);
        }

        public IEnumerable<ProductWrittenOff> GetAllProductWrittenOffs()
        {
            return FindAll()
                .OrderBy(pwo => pwo.ProductIdFk)
                .ToList();
        }

        public ProductWrittenOff GetProductWrittenOffById(int woStockId, int prodId)
        {
            return FindByCondition(wo => wo.ProductIdFk.Equals(prodId) && wo.WrittenOffStockIdFk.Equals(woStockId))
                .FirstOrDefault();
        }

        public ProductWrittenOff GetProductWrittenOffDetails(int woStockId, int prodId)
        {
            return FindByCondition(wo => wo.ProductIdFk.Equals(prodId) && wo.WrittenOffStockIdFk.Equals(woStockId))
                .Include(p => p.ProductIdFkNavigation)
                .Include(wos => wos.WrittenOffStockIdFkNavigation)
                .Include(wor => wor.WriteOffReason)
                .FirstOrDefault();
        }

        public void UpdateProductWrittenOff(ProductWrittenOff prdWO)
        {
            Update(prdWO);
        }

        public IEnumerable<ProductWrittenOff> WrittenOffByProduct(int productId)
        {
            return FindByCondition(wo => wo.ProductIdFk.Equals(productId)).ToList();
        }
    }
}
