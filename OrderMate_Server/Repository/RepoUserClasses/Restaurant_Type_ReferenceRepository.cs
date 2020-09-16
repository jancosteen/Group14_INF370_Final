using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Restaurant_Type_ReferenceRepository: RepositoryBase<RestaurantTypeReference>, IRestaurant_Type_ReferenceRepository
    {
        public Restaurant_Type_ReferenceRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateRestaurantTypeReference(RestaurantTypeReference resTypeRef)
        {
            Create(resTypeRef);
        }

        public void DeleteRestaurantTypeReference(RestaurantTypeReference resTypeRef)
        {
            Delete(resTypeRef);
        }

        public IEnumerable<RestaurantTypeReference> GetAllRestaurantTypeReferences()
        {
            return FindAll()
                .OrderBy(rt => rt.RestaurantTypeIdFk)
                .ToList();
        }

        public RestaurantTypeReference GetRestaurantTypeReferenceById(int resTypeId, int resId)
        {
            return FindByCondition(rt => rt.RestaurantTypeIdFk.Equals(resTypeId) && rt.RestaurantIdFk.Equals(resId))
                .FirstOrDefault();
        }

        public RestaurantTypeReference GetRestaurantTypeReferenceDetails(int resTypeId, int resId)
        {
            return FindByCondition(rt => rt.RestaurantTypeIdFk.Equals(resTypeId) && rt.RestaurantIdFk.Equals(resId))
                .Include(rt => rt.RestaurantIdFkNavigation)
                .Include(rt => rt.RestaurantTypeIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateRestaurantTypeReference(RestaurantTypeReference resTypeRef)
        {
            Update(resTypeRef);
        }
    }
}
