using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Restaurant_TypeRepository: RepositoryBase<RestaurantType>, IRestaurant_TypeRepository
    {
        public Restaurant_TypeRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateRestaurantType(RestaurantType restaurantType)
        {
            Create(restaurantType);
        }

        public void DeleteRestaurantType(RestaurantType restaurantType)
        {
            Delete(restaurantType);
        }

        public IEnumerable<RestaurantType> GetAllRestaurantTypes()
        {
            return FindAll()
                .OrderBy(rt => rt.RestaurantTypeId)
                .ToList();
        }

        public RestaurantType GetRestaurantTypeById(int restaurantTypeId)
        {
            return FindByCondition(rt => rt.RestaurantTypeId.Equals(restaurantTypeId))
                .FirstOrDefault();
        }

        public RestaurantType GetRestaurantTypeWithDetails(int restaurantTypeId)
        {
            return FindByCondition(rt => rt.RestaurantTypeId.Equals(restaurantTypeId))
                .Include(rt => rt.RestaurantTypeReference)
                .FirstOrDefault();
        }

        public void UpdateRestaurantType(RestaurantType restaurantType)
        {
            Update(restaurantType);
        }
    }
}
