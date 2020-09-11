using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IRestaurantRepository: IRepositoryBase<Restaurant>
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        Restaurant GetRestaurantById(int restaurantId);
        Restaurant GetRestaurantWithDetails(int restaurantId);
        Restaurant GetRestaurantByQrCode(int qrCodeId);
        void CreateRestaurant(Restaurant restaurant);
        void UpdateRestaurant(Restaurant restaurant);
        void DeleteRestaurant(Restaurant restaurant);
    }
}
