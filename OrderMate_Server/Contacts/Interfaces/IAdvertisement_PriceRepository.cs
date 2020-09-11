using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IAdvertisement_PriceRepository: IRepositoryBase<AdvertisementPrice>
    {
        IEnumerable<AdvertisementPrice> GetAllAdvPrices();
        AdvertisementPrice GetAdvertisementPriceById(int advPriceId);
        AdvertisementPrice GetAdvertisementPriceWithDetails(int advPriceId);
        void CreateAdvertisementPrice(AdvertisementPrice advPrice);
        void UpdateAdvertisementPrice(AdvertisementPrice advPrice);
        void DeleteAdvertisementPrice(AdvertisementPrice advPrice);
    }
}
