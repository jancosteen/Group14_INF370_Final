using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IStock_Take_Repository: IRepositoryBase<StockTake>
    {
        IEnumerable<StockTake> GetAllStockTakes();
        StockTake GetStockTakeById(int stockTakeId);
        StockTake GetStockTakeDetails(int stockTakeId);
        void CreateStockTake(StockTake stockTake);
        void UpdateStockTake(StockTake stockTake);
        void DeleteStockTake(StockTake stockTake);

    }
}
