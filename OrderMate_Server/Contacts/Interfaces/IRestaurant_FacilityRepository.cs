using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IRestaurant_FacilityRepository: IRepositoryBase<RestaurantFacility>
    {
        IEnumerable<RestaurantFacility> GetAllRestaurantFacilitys();
        RestaurantFacility GetRestaurantFacilityById(int restaurantFacilityId);
        RestaurantFacility GetRestaurantFacilityWithDetails(int restaurantFacilityId);
        void CreateRestaurantFacility(RestaurantFacility restaurantFacility);
        void UpdateRestaurantfacility(RestaurantFacility restaurantFacility);
        void DeleteRestaurantFacility(RestaurantFacility restaurantFacility);
    }
}
