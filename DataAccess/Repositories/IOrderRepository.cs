using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace DataAccess.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        IEnumerable<Order> GetOrdersByCustomer(string customerId);
        IEnumerable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
    }
}