using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface ISupplierRepository: IRepositoryBase<Supplier>
    {
        IEnumerable<Supplier> GetAllSuppliers();
        Supplier GetSupplierById(int supplierId);
        Supplier GetSupplierWithOrderDetails(int supplierId);
        void CreateSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
    }
}
