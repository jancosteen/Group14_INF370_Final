using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface ISpecial_PriceRepository: IRepositoryBase<SpecialPrice>
    {
        IEnumerable<SpecialPrice> GetAllSpecialPricees();
        SpecialPrice GetSpecialPriceById(int specialPriceId);
        SpecialPrice GetSpecialPriceWithDetails(int specialPriceId);
        void CreateSpecialPrice(SpecialPrice specialPrice);
        void UpdateSpecialPrice(SpecialPrice specialPrice);
        void DeleteSpecialPrice(SpecialPrice specialPrice);
    }
}
