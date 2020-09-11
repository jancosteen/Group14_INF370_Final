using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IAdvertisementRepository: IRepositoryBase<Advertisement>
    {
        IEnumerable<Advertisement> GetAllAdvertisements();
        Advertisement GetAdvertisementById(int advId);
        Advertisement GetAdvertisementWithDetails(int advId);
        void CreateAdvertisement(Advertisement adv);
        void UpdateAdvertisement(Advertisement adv);
        void DeleteAdvertisement(Advertisement adv);
    }
}
