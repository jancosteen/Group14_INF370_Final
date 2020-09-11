using Contacts;
using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class SupplierOrderRepository:RepositoryBase<SupplierOrder>, ISupplierOrderRepository
    {
        public SupplierOrderRepository (OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateSupplierOrder(SupplierOrder sOrder)
        {
            Create(sOrder);
        }

        public void DeleteSupplierOrder(SupplierOrder sOrder)
        {
            Delete(sOrder);
        }

        public IEnumerable<SupplierOrder> GetAllSupplierOrders()
        {
            return FindAll()
                .OrderBy(so => so.SupplierIdFk)
                .ToList();
        }

        public SupplierOrder GetSupplierOrderById(int supOrderId)
        {
            return FindByCondition(so => so.SupplierOrderId.Equals(supOrderId))
                .FirstOrDefault();
        }

        public IEnumerable<SupplierOrder> SupplierOrdersBySupplier(int supplierIid)
        {
            return FindByCondition(so => so.SupplierIdFk.Equals(supplierIid))
                .ToList();
        }

        public void UpdateSupplierOrder(SupplierOrder sOrder)
        {
            Update(sOrder);
        }

        SupplierOrder ISupplierOrderRepository.GetSupplierOrderWithDetails(int supOrderId)
        {
            return FindByCondition(so => so.SupplierOrderId.Equals(supOrderId))
                .Include(s => s.SupplierIdFkNavigation)
                .Include(sl => sl.SupplierOrderLine).ThenInclude(p => p.ProductIdFkNavigation).ThenInclude(p => p.ProductCategoryIdFkNavigation)
                .Include(sl => sl.SupplierOrderLine).ThenInclude(p => p.ProductIdFkNavigation).ThenInclude(p => p.ProductReorderFreqIdFkNavigation)
                .Include(sl => sl.SupplierOrderLine).ThenInclude(p => p.ProductIdFkNavigation).ThenInclude(p => p.ProductTypeIdFkNavigation)
                .FirstOrDefault();
        }
    }
}
