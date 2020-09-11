using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IRestaurant_TypeRepository: IRepositoryBase<RestaurantType>
    {
        IEnumerable<RestaurantType> GetAllRestaurantTypes();
        RestaurantType GetRestaurantTypeById(int restaurantTypeId);
        RestaurantType GetRestaurantTypeWithDetails(int restaurantTypeId);
        void CreateRestaurantType(RestaurantType restaurantType);
        void UpdateRestaurantType(RestaurantType restaurantType);
        void DeleteRestaurantType(RestaurantType restaurantType);
    }
}
