using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class AdvertisementRepository: RepositoryBase<Advertisement>, IAdvertisementRepository
    {
        public AdvertisementRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateAdvertisement(Advertisement adv)
        {
            Create(adv);
        }

        public void DeleteAdvertisement(Advertisement adv)
        {
            Delete(adv);
        }

        public Advertisement GetAdvertisementById(int advId)
        {
            return FindByCondition(ad => ad.AdvertisementId.Equals(advId))
                .FirstOrDefault();
        }

        public Advertisement GetAdvertisementWithDetails(int advId)
        {
            return FindByCondition(ad => ad.AdvertisementId.Equals(advId))
                .Include(ad => ad.AdvertisementPriceIdFk)
                .Include(ad => ad.RestaurantAdvertisement)
                .Include(ad => ad.AdvertisementDateIdFk)
                .FirstOrDefault();
        }

        public IEnumerable<Advertisement> GetAllAdvertisements()
        {
            return FindAll()
                .OrderBy(ad => ad.AdvertisementId)
                .ToList();
        }

        public void UpdateAdvertisement(Advertisement adv)
        {
            Update(adv);
        }
    }
}
