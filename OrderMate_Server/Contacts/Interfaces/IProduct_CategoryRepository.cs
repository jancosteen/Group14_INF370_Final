using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IProduct_CategoryRepository : IRepositoryBase<ProductCategory>
    {
        IEnumerable<ProductCategory> GetAllProductCategories();
        ProductCategory GetProductCategoryById(int prodCatId);
        ProductCategory GetProductCategoryWithProducts(int prodCatId);
        void CreateProdCategory(ProductCategory prodCategory);
        void UpdateProdCategory(ProductCategory prodCategory);
        void DeleteProdCategory(ProductCategory prodCategory);
        
    }
}
