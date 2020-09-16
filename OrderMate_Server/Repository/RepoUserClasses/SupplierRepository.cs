using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class SupplierRepository: RepositoryBase<Supplier>,ISupplierRepository
    {
        public SupplierRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateSupplier(Supplier supplier)
        {
            Create(supplier);
        }

        public void DeleteSupplier(Supplier supplier)
        {
            Delete(supplier);
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return FindAll()
                .OrderBy(s => s.SupplierName)
                .ToList();
        }

        public Supplier GetSupplierById(int supplierId)
        {
            return FindByCondition(s => s.SupplierId.Equals(supplierId))
                .FirstOrDefault();
        }

        public Supplier GetSupplierWithOrderDetails(int supplierId)
        {
            return FindByCondition(s => s.SupplierId.Equals(supplierId))
                .Include(so => so.SupplierOrder)
                .FirstOrDefault();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            Update(supplier);
        }
    }
}
