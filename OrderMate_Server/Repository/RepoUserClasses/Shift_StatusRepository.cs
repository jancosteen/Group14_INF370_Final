using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Shift_StatusRepository: RepositoryBase<ShiftStatus>, IShift_StatusRepository
    {
        public Shift_StatusRepository(OrderMateDbDel08Context repositoryContext): base(repositoryContext)
        {

        }

        public void CreateShiftStatus(ShiftStatus shiftStatus)
        {
            Create(shiftStatus);
        }

        public void DeleteShiftStatus(ShiftStatus shiftStatus)
        {
            Delete(shiftStatus);
        }

        public IEnumerable<ShiftStatus> GetAllShiftStatusses()
        {
            return FindAll()
                .OrderBy(ss => ss.ShiftStatusId)
                .ToList();
        }

        public ShiftStatus GetShiftStatusById(int shiftStatusId)
        {
            return FindByCondition(ss => ss.ShiftStatusId.Equals(shiftStatusId))
                .FirstOrDefault();
        }

        public ShiftStatus GetShiftStatusDetails(int shiftStatusId)
        {
            return FindByCondition(ss => ss.ShiftStatusId.Equals(shiftStatusId))
                .Include(ss => ss.Shift)
                .FirstOrDefault();
        }

        public void UpdateShiftStatus(ShiftStatus shiftStatus)
        {
            Update(shiftStatus);
        }
    }
}
