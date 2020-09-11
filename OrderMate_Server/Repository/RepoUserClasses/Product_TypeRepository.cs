using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Product_TypeRepository: RepositoryBase<ProductType>, IProduct_TypeRepository
    {
        public Product_TypeRepository(OrderMateDbFinalContext repositoryContext): base(repositoryContext)
        {

        }

        public void CreateProdType(ProductType prodType)
        {
            Create(prodType);
        }

        public void DeleteProdType(ProductType productType)
        {
            Delete(productType);
        }

        public IEnumerable<ProductType> GetAllProductTypes()
        {
            return FindAll()
                .OrderBy(pt => pt.ProductType1)
                .ToList();
        }

        public ProductType GetProductTypeById(int prodTypeId)
        {
            return FindByCondition(pt => pt.ProductTypeId.Equals(prodTypeId))
                .FirstOrDefault();
        }

        public ProductType GetProductTypeWithProducts(int prodTypeId)
        {
            return FindByCondition(pt => pt.ProductTypeId.Equals(prodTypeId))
                .Include(p => p.Product)
                .FirstOrDefault();
        }

        public void UpdateProdType(ProductType prodType)
        {
            Update(prodType);
        }
    }
}
