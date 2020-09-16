using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class ProductRepository: RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(OrderMateDbDel08Context repositoryContext): base(repositoryContext)
        {

        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return FindAll()
                .OrderBy(p => p.ProductName)
                .ToList();
        }

        public Product GetProductById(int prodId)
        {
            return FindByCondition(p => p.ProductId.Equals(prodId))
                .FirstOrDefault();
        }

        public Product GetProductWithDetails(int prodId)
        {
            return FindByCondition(p => p.ProductId.Equals(prodId))
                .Include(p => p.ProductReorderFreqIdFkNavigation)
                .Include(p => p.ProductTypeIdFkNavigation)
                .Include(p => p.ProductCategoryIdFkNavigation)
                .Include(p => p.ProductStockTake)
                .Include(p => p.ProductWrittenOff)
                .Include(p => p.SupplierOrderLine)
                .FirstOrDefault();
        }

        public void UpdateProduct(Product product)
        {
            Update(product);
        }
    }
}
