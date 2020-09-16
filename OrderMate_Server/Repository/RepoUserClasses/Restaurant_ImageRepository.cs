using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Restaurant_ImageRepository: RepositoryBase<RestaurantImage>, IRestaurant_ImageRepository
    {
        public Restaurant_ImageRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateRestaurantImage(RestaurantImage restaurantImage)
        {
            Create(restaurantImage);
        }

        public void DeleteRestaurantImage(RestaurantImage restaurantImage)
        {
            Delete(restaurantImage);
        }

        public IEnumerable<RestaurantImage> GetAllRestaurantImages()
        {
            return FindAll()
                .OrderBy(ri => ri.RestaurantImageId)
                .ToList();
        }

        public RestaurantImage GetRestaurantImageById(int restaurantImageId)
        {
            return FindByCondition(ri => ri.RestaurantImageId.Equals(restaurantImageId))
                .FirstOrDefault();
        }

        public RestaurantImage GetRestaurantImageWithDetails(int restaurantImageId)
        {
            return FindByCondition(ri => ri.RestaurantImageId.Equals(restaurantImageId))
                .Include(ri => ri.RestaurantIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateRestaurantImage(RestaurantImage restaurantImage)
        {
            Update(restaurantImage);
        }
    }
}
