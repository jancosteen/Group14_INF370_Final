using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface ISpecialRepository: IRepositoryBase<Special>
    {
        IEnumerable<Special> GetAllSpecials();
        Special GetSpecialById(int specialId);
        Special GetSpecialWithDetails(int specialId);
        void CreateSpecial(Special special);
        void UpdateSpecial(Special special);
        void DeleteSpecial(Special special);
    }
}
