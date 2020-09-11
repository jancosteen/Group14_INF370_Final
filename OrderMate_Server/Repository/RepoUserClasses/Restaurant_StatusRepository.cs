using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Restaurant_StatusRepository: RepositoryBase<RestaurantStatus>, IRestaurant_StatusRepository
    {
        public Restaurant_StatusRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateRestaurantStatus(RestaurantStatus restaurantStatus)
        {
            Create(restaurantStatus);
        }

        public void DeleteRestaurantStatus(RestaurantStatus restaurantStatus)
        {
            Delete(restaurantStatus);
        }

        public IEnumerable<RestaurantStatus> GetAllRestaurantStatusses()
        {
            return FindAll()
                .OrderBy(rs => rs.RestaurantStatusId)
                .ToList();
        }

        public RestaurantStatus GetRestaurantStatusById(int restaurantStatusId)
        {
            return FindByCondition(rs => rs.RestaurantStatusId.Equals(restaurantStatusId))
                .FirstOrDefault();
        }

        public RestaurantStatus GetRestaurantStatusWithDetails(int restaurantStatusId)
        {
            return FindByCondition(rs => rs.RestaurantStatusId.Equals(restaurantStatusId))
                .Include(rs => rs.Restaurant)
                .FirstOrDefault();
        }

        public void UpdateRestaurantStatus(RestaurantStatus restaurantStatus)
        {
            Update(restaurantStatus);
        }
    }
}
