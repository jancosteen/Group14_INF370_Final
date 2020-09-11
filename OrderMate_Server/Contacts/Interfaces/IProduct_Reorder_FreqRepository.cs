using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IProduct_Reorder_FreqRepository : IRepositoryBase<ProductReorderFreq>
    {
        IEnumerable<ProductReorderFreq> GetAllProductReorderFreqs();
        ProductReorderFreq GetProductReorderFreqById(int prodReorderId);
        ProductReorderFreq GetProductReorderFreqWithProducts(int prodReorderId);
        void CreateProdRFreq(ProductReorderFreq prodRFreq);
        void UpdateProdRFreq(ProductReorderFreq prodRFreq);
        void DeleteProdRFreq(ProductReorderFreq prodRFreq);
        
    }
}
