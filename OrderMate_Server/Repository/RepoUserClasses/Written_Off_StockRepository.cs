using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Written_Off_StockRepository: RepositoryBase<WrittenOffStock>, IWritten_Off_StockRepository
    {
        public Written_Off_StockRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateWrittenOfStock(WrittenOffStock writtenOffStock)
        {
            Create(writtenOffStock);
        }

        public IEnumerable<WrittenOffStock> GetAllWrittenOffStocks()
        {
            return FindAll()
                .OrderBy(wos => wos.WrittenOfStockDate)
                .ToList();
        }

        public WrittenOffStock GetWrittenOffStockById(int woStockId)
        {
            return FindByCondition(wos => wos.WrittenOfStockId.Equals(woStockId))
                .FirstOrDefault();
        }

        public WrittenOffStock GetWrittenOffStockDetails(int woStockId)
        {
            return FindByCondition(wos => wos.WrittenOfStockId.Equals(woStockId))
                .Include(pwo => pwo.ProductWrittenOff)
                .FirstOrDefault();
        }

        public void UpdateWrittenOfStock(WrittenOffStock writtenOffStock)
        {
            Update(writtenOffStock);
        }
    }
}
