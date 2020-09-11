using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Contacts.Interfaces
{
    public interface ISupplierOrderRepository :IRepositoryBase<SupplierOrder>
    {
        //delete validation 
        IEnumerable<SupplierOrder> SupplierOrdersBySupplier(int supplierIid);
        IEnumerable<SupplierOrder> GetAllSupplierOrders();
        SupplierOrder GetSupplierOrderById(int supOrderId);
        SupplierOrder GetSupplierOrderWithDetails(int supOrderId);
        void CreateSupplierOrder(SupplierOrder sOrder);
        void UpdateSupplierOrder(SupplierOrder sOrder);
        void DeleteSupplierOrder(SupplierOrder sOrder);

    }
}
