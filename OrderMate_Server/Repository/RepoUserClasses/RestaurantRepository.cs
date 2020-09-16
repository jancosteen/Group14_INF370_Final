using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class RestaurantRepository: RepositoryBase<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateRestaurant(Restaurant restaurant)
        {
            Create(restaurant);
        }

        public void DeleteRestaurant(Restaurant restaurant)
        {
            Delete(restaurant);
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return FindAll()
                .OrderBy(r => r.RestaurantName)
                .ToList();
        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            return FindByCondition(r => r.RestaurantId.Equals(restaurantId))
                .FirstOrDefault();
        }

        public Restaurant GetRestaurantWithDetails(int restaurantId)
        {
            return FindByCondition(r => r.RestaurantId.Equals(restaurantId))
                .Include(r => r.Employee)
                .Include(r => r.MenuRestaurant)
                .Include(r => r.ResaurantFacilityRef)
                .Include(r => r.RestaurantAdvertisement)
                .Include(r => r.RestaurantImage)
                .Include(r => r.RestaurantStatusIdFkNavigation)
                .Include(r => r.RestaurantTypeReference)
                .Include(r => r.SeatingLayout)
                .Include(r => r.SocialMedia)
                .Include(r => r.UserComment)
                .FirstOrDefault();
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            Update(restaurant);
        }
    }
}
