using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IRestaurant_Facility_RefRepository: IRepositoryBase<ResaurantFacilityRef>
    {
        IEnumerable<ResaurantFacilityRef> GetAllRestaurantFacilityRefs();
        ResaurantFacilityRef GetResaurantFacilityRefById(int resFacId, int resId);
        ResaurantFacilityRef GetResaurantFacilityRefDetails(int resFacId, int resId);
        void CreateResaurantFacilityRef(ResaurantFacilityRef restaurantFacilityRef);
        void UpdateResaurantFacilityRef(ResaurantFacilityRef restaurantFacilityRef);
        void DeleteResaurantFacilityRef(ResaurantFacilityRef restaurantFacilityRef);
    }
}
