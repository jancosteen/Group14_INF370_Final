using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class AllergyRepository: RepositoryBase<Allergy>, IAllergyRepository
    {
        public AllergyRepository(OrderMateDbDel08Context repositoryContext): base(repositoryContext)
        {

        }

        public void CreateAllergy(Allergy allergy)
        {
            Create(allergy);
        }

        public void DeleteAllergy(Allergy allergy)
        {
            Delete(allergy);
        }

        public IEnumerable<Allergy> GetAllAllergies()
        {
            return FindAll()
                .OrderBy(a => a.AllergyId)
                .ToList();
        }

        public Allergy GetAllergyById(int allergyId)
        {
            return FindByCondition(a => a.AllergyId.Equals(allergyId))
                .FirstOrDefault();
        }

        public Allergy GetAllergyWithDetails(int allergyId)
        {
            return FindByCondition(a => a.AllergyId.Equals(allergyId))
                .Include(a => a.MenuItemAllergy)
                .FirstOrDefault();
        }

        public void UpdateAllergy(Allergy allergy)
        {
            Update(allergy);
        }
    }
}
