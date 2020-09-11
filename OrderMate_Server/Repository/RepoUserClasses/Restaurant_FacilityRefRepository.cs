using Contacts.Interfaces;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Restaurant_FacilityRefRepository: RepositoryBase<ResaurantFacilityRef>, IRestaurant_Facility_RefRepository
    {
        public Restaurant_FacilityRefRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateResaurantFacilityRef(ResaurantFacilityRef restaurantFacilityRef)
        {
            Create(restaurantFacilityRef);
        }

        public void DeleteResaurantFacilityRef(ResaurantFacilityRef restaurantFacilityRef)
        {
            Delete(restaurantFacilityRef);
        }

        public IEnumerable<ResaurantFacilityRef> GetAllRestaurantFacilityRefs()
        {
            return FindAll()
                .OrderBy(rf => rf.RestaurantIdFk)
                .ToList();
        }

        public ResaurantFacilityRef GetResaurantFacilityRefById(int resFacId, int resId)
        {
            return FindByCondition(rf => rf.RestaurantFacilityIdFk.Equals(resFacId) && rf.RestaurantIdFk.Equals(resId))
                .FirstOrDefault();
        }

        public ResaurantFacilityRef GetResaurantFacilityRefDetails(int resFacId, int resId)
        {
            return FindByCondition(rf => rf.RestaurantFacilityIdFk.Equals(resFacId) && rf.RestaurantIdFk.Equals(resId))
                .Include(rf => rf.RestaurantFacilityIdFkNavigation)
                .Include(rf => rf.RestaurantIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateResaurantFacilityRef(ResaurantFacilityRef restaurantFacilityRef)
        {
            Update(restaurantFacilityRef);
        }
    }
}
