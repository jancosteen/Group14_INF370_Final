using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IWritten_Off_StockRepository: IRepositoryBase<WrittenOffStock>
    {
        IEnumerable<WrittenOffStock> GetAllWrittenOffStocks();
        WrittenOffStock GetWrittenOffStockById(int woStockId);
        WrittenOffStock GetWrittenOffStockDetails(int woStockId);
        void CreateWrittenOfStock(WrittenOffStock writtenOffStock);
        void UpdateWrittenOfStock(WrittenOffStock writtenOffStock);
        
    }
}
