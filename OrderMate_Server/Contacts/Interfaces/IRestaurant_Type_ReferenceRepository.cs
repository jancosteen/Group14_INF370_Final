using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IRestaurant_Type_ReferenceRepository: IRepositoryBase<RestaurantTypeReference>
    {
        IEnumerable<RestaurantTypeReference> GetAllRestaurantTypeReferences();
        RestaurantTypeReference GetRestaurantTypeReferenceById(int resTypeId, int resId);
        RestaurantTypeReference GetRestaurantTypeReferenceDetails(int resTypeId, int resId);
        void CreateRestaurantTypeReference(RestaurantTypeReference resTypeRef);
        void UpdateRestaurantTypeReference(RestaurantTypeReference resTypeRef);
        void DeleteRestaurantTypeReference(RestaurantTypeReference resTypeRef);
    }
}
