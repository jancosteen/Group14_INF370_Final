using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface ISupplierOrderLineRepository: IRepositoryBase<SupplierOrderLine>
    {
        IEnumerable<SupplierOrderLine> SupplierOrderLinesByProduct(int productId);

        IEnumerable<SupplierOrderLine> GetSupplierOrderLines();
        SupplierOrderLine GetSupOrderLineBySupplierOrderId(int supOrderId);
        SupplierOrderLine GetSupOrderLineBySupplierOrderIdWithDetails(int supOrderId);
        SupplierOrderLine GetSupOrderLineByProductId(int productId);
        SupplierOrderLine GetSupOrderLineByProductIdWithDetails(int productId);
        SupplierOrderLine GetSupOrderLineByProductIdAndSupOrderIdWithDetails(int prodId, int sOrderId);
        SupplierOrderLine GetSupOrderLineBySupplierOrderIdAndProdId(int sOrderId, int prodId);
        void CreateSupplierOrderLne(SupplierOrderLine sOrderLine);
        void UpdateSupplierOrderLine(SupplierOrderLine sOrderLine);
        void DeleteSupplierOrderLine(SupplierOrderLine sOrderLine);
    }
}
