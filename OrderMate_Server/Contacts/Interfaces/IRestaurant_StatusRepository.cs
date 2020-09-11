using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IRestaurant_StatusRepository: IRepositoryBase<RestaurantStatus>
    {
        IEnumerable<RestaurantStatus> GetAllRestaurantStatusses();
        RestaurantStatus GetRestaurantStatusById(int restaurantStatusId);
        RestaurantStatus GetRestaurantStatusWithDetails(int restaurantStatusId);
        void CreateRestaurantStatus(RestaurantStatus restaurantStatus);
        void UpdateRestaurantStatus(RestaurantStatus restaurantStatus);
        void DeleteRestaurantStatus(RestaurantStatus restaurantStatus);
    }
}
