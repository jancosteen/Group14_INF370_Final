using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Advertisement_DateRepository: RepositoryBase<AdvertisementDate>, IAdvertisement_DateRepository
    {
        public Advertisement_DateRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateAdvDate(AdvertisementDate advDate)
        {
            Create(advDate);
        }

        public void DeleteAdvDate(AdvertisementDate advDate)
        {
            Create(advDate);
        }

        public AdvertisementDate GetAdvDateById(int advDateId)
        {
            return FindByCondition(ad => ad.AdvertisementDateId.Equals(advDateId))
                .FirstOrDefault();
        }

        public AdvertisementDate GetAdvDateWithDetails(int advDateId)
        {
            return FindByCondition(ad => ad.AdvertisementDateId.Equals(advDateId))
                .Include(ad => ad.Advertisement)
                .FirstOrDefault();
        }

        public IEnumerable<AdvertisementDate> GetAllAdvDates()
        {
            return FindAll()
                .OrderBy(ad => ad.AdvertisementDateId)
                .ToList();
        }

        public void UpdateAdvDate(AdvertisementDate advDate)
        {
            Update(advDate);
        }
    }
}
