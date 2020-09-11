using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface ILayout_TypeRepository: IRepositoryBase<LayoutType>
    {
        IEnumerable<LayoutType> GetAllLayoutTypess();
        LayoutType GetLayoutTypeById(int layoutTypeId);
        LayoutType GetLayoutTypeWithDetails(int layoutTypeId);
        void CreateLayoutType(LayoutType layoutType);
        void UpdateLayoutType(LayoutType layoutType);
        void DeleteLayoutType(LayoutType layoutType);
    }
}
