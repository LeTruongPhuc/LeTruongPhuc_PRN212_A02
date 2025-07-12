using BusinessObjects;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(LucySalesDbContext context) : base(context)
        {
        }

        public IEnumerable<Order> GetOrdersByCustomer(string customerId)
        {
            return _context.Orders
                .Where(o => o.CustomerID == customerId)
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .ToList();
        }

        public IEnumerable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }
    }
}