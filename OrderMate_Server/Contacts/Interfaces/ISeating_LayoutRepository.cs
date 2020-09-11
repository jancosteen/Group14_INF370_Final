using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface ISeating_LayoutRepository: IRepositoryBase<SeatingLayout>
    {
        IEnumerable<SeatingLayout> GetAllSeatingLayouts();
        SeatingLayout GetSeatingLayoutById(int seatingLayoutId);
        SeatingLayout GetSeatingLayoutDetails(int seatingLayoutId);
        void CreateSeatingLayout(SeatingLayout seatingLayout);
        void UpdateSeatingLayout(SeatingLayout seatingLayout);
        void DeleteSeatingLayout(SeatingLayout seatingLayout);
    }
}
