using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Write_Off_ReasonRepository: RepositoryBase<WriteOffReason>, IWrite_Off_ReasonRepository
    {
        public Write_Off_ReasonRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateWriteOffReason(WriteOffReason woReason)
        {
            Create(woReason);
        }

        public IEnumerable<WriteOffReason> GetAllWriteOffReasons()
        {
            return FindAll()
                .OrderBy(wor => wor.WriteOffReasonId)
                .ToList();
        }

        public WriteOffReason GetWriteOffReasonById(int woStockId, int prodId)
        {
            return FindByCondition(wor => wor.ProductIdFkFk.Equals(prodId) && wor.WrittenOffStockIdFkFk.Equals(woStockId))
                .FirstOrDefault();
        }

        public WriteOffReason GetWriteOffReasonDetails(int woStockId, int prodId)
        {
            return FindByCondition(wor => wor.ProductIdFkFk.Equals(prodId) && wor.WrittenOffStockIdFkFk.Equals(woStockId))
                .Include(pwo => pwo.ProductWrittenOff)
                .FirstOrDefault();
        }

        public void UpdateWriteOffReason(WriteOffReason woReason)
        {
            Update(woReason);
        }
    }
}
