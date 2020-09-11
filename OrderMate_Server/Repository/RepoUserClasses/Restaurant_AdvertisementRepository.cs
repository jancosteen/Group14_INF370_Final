using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Restaurant_AdvertisementRepository: RepositoryBase<RestaurantAdvertisement>, IRestaurant_AdvertisementRepository
    {
        public Restaurant_AdvertisementRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateRestaurantAdvertisement(RestaurantAdvertisement restaurantAdvertisement)
        {
            Create(restaurantAdvertisement);
        }

        public void DeleteRestaurantAdvertisement(RestaurantAdvertisement restaurantAdvertisement)
        {
            Delete(restaurantAdvertisement);
        }

        public IEnumerable<RestaurantAdvertisement> GetAllRestaurantAdvertisements()
        {
            return FindAll()
                .OrderBy(rad => rad.RestaurantIdFk)
                .ToList();
        }

        public RestaurantAdvertisement GetRestaurantAdvertisementById(int resId, int advId)
        {
            return FindByCondition(rad => rad.RestaurantIdFk.Equals(resId) && rad.AdvertisementIdFk.Equals(advId))
                .FirstOrDefault();
        }

        public RestaurantAdvertisement GetRestaurantAdvertisementDetails(int resId, int advId)
        {
            return FindByCondition(rad => rad.RestaurantIdFk.Equals(resId) && rad.AdvertisementIdFk.Equals(advId))
                .Include(rad => rad.AdvertisementIdFkNavigation)
                .Include(rad => rad.RestaurantIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateRestaurantAdvertisement(RestaurantAdvertisement restaurantAdvertisement)
        {
            Update(restaurantAdvertisement);
        }
    }
}
