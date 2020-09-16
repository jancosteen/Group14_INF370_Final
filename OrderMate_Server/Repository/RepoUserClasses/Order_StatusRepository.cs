using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Order_StatusRepository: RepositoryBase<OrderStatus>, IOrder_StatusRepository
    {
        public Order_StatusRepository(OrderMateDbDel08Context repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateOrderStatus(OrderStatus orderStatus)
        {
            Create(orderStatus);
        }

        public void DeleteOrderStatus(OrderStatus orderStatus)
        {
            Delete(orderStatus);
        }

        public IEnumerable<OrderStatus> GetAllOrderStatusses()
        {
            return FindAll()
                .OrderBy(os => os.OrderStatusId)
                .ToList();
        }

        public OrderStatus GetOrderStatusById(int orderStatusId)
        {
            return FindByCondition(os => os.OrderStatusId.Equals(orderStatusId))
                .FirstOrDefault();
        }

        public OrderStatus GetOrderStatusWithDetails(int orderStatusId)
        {
            return FindByCondition(os => os.OrderStatusId.Equals(orderStatusId))
                .Include(os => os.Order)
                .FirstOrDefault();
        }

        public void UpdateOrderStatus(OrderStatus orderStatus)
        {
            Update(orderStatus);
        }
    }
}
