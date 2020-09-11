using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IWrite_Off_ReasonRepository: IRepositoryBase<WriteOffReason>
    {
        IEnumerable<WriteOffReason> GetAllWriteOffReasons();
        WriteOffReason GetWriteOffReasonById(int woStockId, int prodId);
        WriteOffReason GetWriteOffReasonDetails(int woStockId, int prodId);
        void CreateWriteOffReason(WriteOffReason woReason);
        void UpdateWriteOffReason(WriteOffReason woReason);
    }
}
