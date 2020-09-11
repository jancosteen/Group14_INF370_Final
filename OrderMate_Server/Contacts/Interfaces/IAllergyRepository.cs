using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IAllergyRepository: IRepositoryBase<Allergy>
    {
        IEnumerable<Allergy> GetAllAllergies();
        Allergy GetAllergyById(int allergyId);
        Allergy GetAllergyWithDetails(int allergyId);
        void CreateAllergy(Allergy allergy);
        void UpdateAllergy(Allergy allergy);
        void DeleteAllergy(Allergy allergy);
    }
}
