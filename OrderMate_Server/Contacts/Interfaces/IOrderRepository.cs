using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Interfaces
{
    public interface IOrderRepository: IRepositoryBase<Order>
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int orderId);
        Order GetOrderByQrCodeId(int qrCodeId);
        Order GetOrderWithDetails(int orderId);
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order);
    }
}
