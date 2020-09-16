using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Advertisement_PriceRepository: RepositoryBase<AdvertisementPrice>, IAdvertisement_PriceRepository
    {
        public Advertisement_PriceRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateAdvertisementPrice(AdvertisementPrice advPrice)
        {
            Create(advPrice);
        }

        public void DeleteAdvertisementPrice(AdvertisementPrice advPrice)
        {
            Delete(advPrice);
        }

        public AdvertisementPrice GetAdvertisementPriceById(int advPriceId)
        {
            return FindByCondition(ad => ad.AdvertisementPriceId.Equals(advPriceId))
                 .FirstOrDefault();
        }

        public AdvertisementPrice GetAdvertisementPriceWithDetails(int advPriceId)
        {
            return FindByCondition(ad => ad.AdvertisementPriceId.Equals(advPriceId))
                .Include(ad => ad.Advertisement)
                .FirstOrDefault();
        }

        public IEnumerable<AdvertisementPrice> GetAllAdvPrices()
        {
            return FindAll()
                .OrderBy(ad => ad.AdvertisementPriceId)
                .ToList();
        }

        public void UpdateAdvertisementPrice(AdvertisementPrice advPrice)
        {
            Update(advPrice);
        }
    }
}
