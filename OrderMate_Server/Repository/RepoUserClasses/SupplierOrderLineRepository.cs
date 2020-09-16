using Contacts;
using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class SupplierOrderLineRepository: RepositoryBase<SupplierOrderLine>, ISupplierOrderLineRepository
    {
        public SupplierOrderLineRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateSupplierOrderLne(SupplierOrderLine sOrderLine)
        {
            Create(sOrderLine);
        }

        public void DeleteSupplierOrderLine(SupplierOrderLine sOrderLine)
        {
            Delete(sOrderLine);
        }

        //Maybe check if FirstOrDefault() needs to be ToList => then go change Interface type to IEnumerable
        public SupplierOrderLine GetSupOrderLineByProductId(int productId)
        {
            return FindByCondition(sol => sol.ProductIdFk.Equals(productId))
                .FirstOrDefault();
        }

        public SupplierOrderLine GetSupOrderLineByProductIdAndSupOrderIdWithDetails(int prodId, int sOrderId)
        {
            return FindByCondition(sol => sol.ProductIdFk.Equals(prodId) && sol.SupplierOrderIdFk.Equals(sOrderId))
                .Include(p => p.ProductIdFkNavigation)
                .Include(so => so.SupplierOrderIdFkNavigation)
                .FirstOrDefault();
        }

        //implemented with only foreign keys not full details
        public SupplierOrderLine GetSupOrderLineByProductIdWithDetails(int productId)
        {
            return FindByCondition(sol => sol.ProductIdFk.Equals(productId))
                .Include(p => p.ProductIdFkNavigation)
                .Include(so => so.SupplierOrderIdFkNavigation)
                .FirstOrDefault();
            /*
              
            */
        }

        public SupplierOrderLine GetSupOrderLineBySupplierOrderId(int supOrderId)
        {
            return FindByCondition(sol => sol.SupplierOrderIdFk.Equals(supOrderId))
                .FirstOrDefault();
        }

        public SupplierOrderLine GetSupOrderLineBySupplierOrderIdAndProdId(int sOrderId, int prodId)
        {
            return FindByCondition(sol => sol.SupplierOrderIdFk.Equals(sOrderId) && sol.ProductIdFk.Equals(prodId))
                .FirstOrDefault();
        }

        //not implemented
        public SupplierOrderLine GetSupOrderLineBySupplierOrderIdWithDetails(int supOrderId)
        {
            return FindByCondition(sol => sol.SupplierOrderIdFk.Equals(supOrderId))
                .Include(p => p.ProductIdFkNavigation)
                .Include(so => so.SupplierOrderIdFkNavigation)
                .FirstOrDefault();
        }

        public IEnumerable<SupplierOrderLine> GetSupplierOrderLines()
        {
            return FindAll()
                .OrderBy(sol => sol.SupplierOrderIdFk)
                .ToList();
        }

        public IEnumerable<SupplierOrderLine> SupplierOrderLinesByProduct(int productId)
        {
            return FindByCondition(sol => sol.ProductIdFk.Equals(productId)).ToList();
        }

        public void UpdateSupplierOrderLine(SupplierOrderLine sOrderLine)
        {
            Update(sOrderLine);
        }
    }
}
