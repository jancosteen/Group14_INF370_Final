using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IRestaurant_AdvertisementRepository: IRepositoryBase<RestaurantAdvertisement>
    {
        IEnumerable<RestaurantAdvertisement> GetAllRestaurantAdvertisements();
        RestaurantAdvertisement GetRestaurantAdvertisementById(int resId, int advId);
        RestaurantAdvertisement GetRestaurantAdvertisementDetails(int resId, int advId);
        void CreateRestaurantAdvertisement(RestaurantAdvertisement restaurantAdvertisement);
        void UpdateRestaurantAdvertisement(RestaurantAdvertisement restaurantAdvertisement);
        void DeleteRestaurantAdvertisement(RestaurantAdvertisement restaurantAdvertisement);
    }
}
