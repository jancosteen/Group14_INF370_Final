using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Stock_TakeRepository: RepositoryBase<StockTake>, IStock_Take_Repository
    {
        public Stock_TakeRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateStockTake(StockTake stockTake)
        {
            Create(stockTake);
        }

        public void DeleteStockTake(StockTake stockTake)
        {
            Delete(stockTake);
        }

        public IEnumerable<StockTake> GetAllStockTakes()
        {
            return FindAll()
                .OrderBy(st => st.StockTakeDate)
                .ToList();
        }

        public StockTake GetStockTakeById(int stockTakeId)
        {
            return FindByCondition(st => st.StockTakeId.Equals(stockTakeId))
                .FirstOrDefault();
        }

        public StockTake GetStockTakeDetails(int stockTakeId)
        {
            return FindByCondition(st => st.StockTakeId.Equals(stockTakeId))
                .Include(x => x.ProductStockTake)
                .FirstOrDefault();
        }

        public void UpdateStockTake(StockTake stockTake)
        {
            Update(stockTake);
        }
    }
}
