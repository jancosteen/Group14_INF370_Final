using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Special_PriceRepository:RepositoryBase<SpecialPrice>, ISpecial_PriceRepository 
    {
        public Special_PriceRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateSpecialPrice(SpecialPrice specialPrice)
        {
            Create(specialPrice);
        }

        public void DeleteSpecialPrice(SpecialPrice specialPrice)
        {
            Delete(specialPrice);
        }

        public IEnumerable<SpecialPrice> GetAllSpecialPricees()
        {
            return FindAll()
                .OrderBy(sp => sp.SpecialIdFk)
                .ToList();
        }

        public SpecialPrice GetSpecialPriceById(int specialPriceId)
        {
            return FindByCondition(sp => sp.SpecialPriceId.Equals(specialPriceId))
                .FirstOrDefault();
        }

        public SpecialPrice GetSpecialPriceWithDetails(int specialPriceId)
        {
            return FindByCondition(sp => sp.SpecialPriceId.Equals(specialPriceId))
                .Include(sp => sp.SpecialIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateSpecialPrice(SpecialPrice specialPrice)
        {
            Update(specialPrice);
        }
    }
}
