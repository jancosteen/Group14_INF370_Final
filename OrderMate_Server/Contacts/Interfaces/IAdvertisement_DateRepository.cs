using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IAdvertisement_DateRepository: IRepositoryBase<AdvertisementDate>
    {
        IEnumerable<AdvertisementDate> GetAllAdvDates();
        AdvertisementDate GetAdvDateById(int advDateId);
        AdvertisementDate GetAdvDateWithDetails(int advDateId);
        void CreateAdvDate(AdvertisementDate advDate);
        void UpdateAdvDate(AdvertisementDate advDate);
        void DeleteAdvDate(AdvertisementDate advDate);
    }
}
