using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Product_CategoryRepository: RepositoryBase<ProductCategory>, IProduct_CategoryRepository
    {
        public Product_CategoryRepository(OrderMateDbFinalContext repositoryContext): base(repositoryContext)
        {

        }

        public void CreateProdCategory(ProductCategory prodCategory)
        {
            Create(prodCategory);
        }

        public void DeleteProdCategory(ProductCategory prodCategory)
        {
            Delete(prodCategory);
        }

        public IEnumerable<ProductCategory> GetAllProductCategories()
        {
            return FindAll()
                .OrderBy(pc => pc.ProductCategory1)
                .ToList();
        }

        public ProductCategory GetProductCategoryById(int prodCatId)
        {
            return FindByCondition(pc => pc.ProductCategoryId.Equals(prodCatId))
                .FirstOrDefault();
        }

        public ProductCategory GetProductCategoryWithProducts(int prodCatId)
        {
            return FindByCondition(pc => pc.ProductCategoryId.Equals(prodCatId))
                .Include(p => p.Product)
                .FirstOrDefault();
        }

        public void UpdateProdCategory(ProductCategory prodCategory)
        {
            Update(prodCategory);
        }
    }
}
