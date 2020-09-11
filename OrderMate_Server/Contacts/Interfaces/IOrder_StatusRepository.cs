using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IOrder_StatusRepository: IRepositoryBase<OrderStatus>
    {
        IEnumerable<OrderStatus> GetAllOrderStatusses();
        OrderStatus GetOrderStatusById(int orderStatusId);
        OrderStatus GetOrderStatusWithDetails(int orderStatusId);
        void CreateOrderStatus(OrderStatus orderStatus);
        void UpdateOrderStatus(OrderStatus orderStatus);
        void DeleteOrderStatus(OrderStatus orderStatus);
    }
}
