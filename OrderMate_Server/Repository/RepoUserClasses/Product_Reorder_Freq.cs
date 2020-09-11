using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Product_Reorder_Freq: RepositoryBase<ProductReorderFreq>, IProduct_Reorder_FreqRepository
    {
        public Product_Reorder_Freq(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateProdRFreq(ProductReorderFreq prodRFreq)
        {
            Create(prodRFreq);
        }

        public void DeleteProdRFreq(ProductReorderFreq prodRFreq)
        {
            Delete(prodRFreq);
        }

        public IEnumerable<ProductReorderFreq> GetAllProductReorderFreqs()
        {
            return FindAll()
                .OrderBy(pr => pr.ProductReorderFreq1)
                .ToList();
        }

        public ProductReorderFreq GetProductReorderFreqById(int prodReorderId)
        {
            return FindByCondition(pr => pr.ProductReorderFreqId.Equals(prodReorderId))
                .FirstOrDefault();
        }

        public ProductReorderFreq GetProductReorderFreqWithProducts(int prodReorderId)
        {
            return FindByCondition(pr => pr.ProductReorderFreqId.Equals(prodReorderId))
                .Include(pr => pr.Product)
                .FirstOrDefault();
        }

        public void UpdateProdRFreq(ProductReorderFreq prodRFreq)
        {
            Update(prodRFreq);
        }
    }
}
