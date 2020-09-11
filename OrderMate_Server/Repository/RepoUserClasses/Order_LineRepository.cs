using Contacts.Interfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.RepoUserClasses
{
    public class Order_LineRepository: RepositoryBase<OrderLine>, IOrder_LineRepository
    {
        public Order_LineRepository(OrderMateDbFinalContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateOrderLine(OrderLine orderLine)
        {
            Create(orderLine);
        }

        public void DeleteOrderLine(OrderLine orderLine)
        {
            Delete(orderLine);
        }

        public IEnumerable<OrderLine> GetAllOrderLines()
        {
            return FindAll()
                .OrderBy(ol => ol.OrderIdFk)
                .ToList();
        }

        public OrderLine GetOrderLineById(int orderLineId)
        {
            return FindByCondition(ol => ol.OrderLineId.Equals(orderLineId))
                .FirstOrDefault();
        }

        public OrderLine GetOrderLineWithDetails(int orderLineId)
        {
            return FindByCondition(ol => ol.OrderLineId.Equals(orderLineId))
                .Include(ol => ol.EmployeeIdFkNavigation)
                .Include(ol => ol.MenuItemIdFkNavigation)
                .Include( ol => ol.OrderIdFkNavigation)
                .Include( ol => ol.SpecialIdFkNavigation)
                .FirstOrDefault();
        }

        public void UpdateOrderLine(OrderLine orderLine)
        {
            Update(orderLine);
        }
    }
}
