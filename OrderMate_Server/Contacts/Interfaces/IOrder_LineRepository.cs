using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IOrder_LineRepository: IRepositoryBase<OrderLine>
    {
        IEnumerable<OrderLine> GetAllOrderLines();
        OrderLine GetOrderLineById(int orderLineId);
        OrderLine GetOrderLineWithDetails(int orderLineId);
        void CreateOrderLine(OrderLine orderLine);
        void UpdateOrderLine(OrderLine orderLine);
        void DeleteOrderLine(OrderLine orderLine);
    }
}
