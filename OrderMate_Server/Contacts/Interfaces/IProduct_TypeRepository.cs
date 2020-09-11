using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IProduct_TypeRepository : IRepositoryBase<ProductType>
    {
        IEnumerable<ProductType> GetAllProductTypes();
        ProductType GetProductTypeById(int prodTypeId);
        ProductType GetProductTypeWithProducts(int prodTypeId);
        void CreateProdType(ProductType prodType);
        void UpdateProdType(ProductType prodType);
        void DeleteProdType(ProductType productType);
       
    }
}
