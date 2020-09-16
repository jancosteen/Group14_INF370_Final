using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Restaurant_FacilityRepository: RepositoryBase<RestaurantFacility>, IRestaurant_FacilityRepository
    {
        public Restaurant_FacilityRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateRestaurantFacility(RestaurantFacility restaurantFacility)
        {
            Create(restaurantFacility);
        }

        public void DeleteRestaurantFacility(RestaurantFacility restaurantFacility)
        {
            Delete(restaurantFacility);
        }

        public IEnumerable<RestaurantFacility> GetAllRestaurantFacilitys()
        {
            return FindAll()
                .OrderBy(rf => rf.RestaurantFacilityId)
                .ToList();
        }

        public RestaurantFacility GetRestaurantFacilityById(int restaurantFacilityId)
        {
            return FindByCondition(rf => rf.RestaurantFacilityId.Equals(restaurantFacilityId))
                .FirstOrDefault();
        }

        public RestaurantFacility GetRestaurantFacilityWithDetails(int restaurantFacilityId)
        {
            return FindByCondition(rf => rf.RestaurantFacilityId.Equals(restaurantFacilityId))
                .Include( rf => rf.ResaurantFacilityRef)
                .FirstOrDefault();
        }

        

        public void UpdateRestaurantfacility(RestaurantFacility restaurantFacility)
        {
            Update(restaurantFacility);
        }
    }
}
