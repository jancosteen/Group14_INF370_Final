using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IRestaurant_ImageRepository: IRepositoryBase<RestaurantImage>
    {
        IEnumerable<RestaurantImage> GetAllRestaurantImages();
        RestaurantImage GetRestaurantImageById(int restaurantImageId);
        RestaurantImage GetRestaurantImageWithDetails(int restaurantImageId);
        void CreateRestaurantImage(RestaurantImage restaurantImage);
        void UpdateRestaurantImage(RestaurantImage restaurantImage);
        void DeleteRestaurantImage(RestaurantImage restaurantImage);
    }
}
