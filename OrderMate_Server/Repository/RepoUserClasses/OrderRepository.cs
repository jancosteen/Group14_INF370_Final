using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class OrderRepository: RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateOrder(Order order)
        {
            Create(order);
        }

        public void DeleteOrder(Order order)
        {
            Delete(order);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return FindAll()
                .OrderBy(o => o.OrderId)
                .ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return FindByCondition(o => o.OrderId.Equals(orderId))
                .FirstOrDefault();
        }

        public Order GetOrderWithDetails(int orderId)
        {
            return FindByCondition(o => o.OrderId.Equals(orderId))
                .Include(o => o.OrderLine)
                .Include( o=> o.OrderStatus)
                .Include( o => o.QrCodeSeating)
                .FirstOrDefault();
        }

        public void UpdateOrder(Order order)
        {
            Update(order);
        }
    }
}
