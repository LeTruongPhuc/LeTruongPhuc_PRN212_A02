using BusinessObjects.Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        Order? GetOrderById(int id);
        IEnumerable<Order> GetOrdersByCustomer(string customerId);
        IEnumerable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate);
        void AddOrder(Order order, IEnumerable<OrderDetail> orderDetails);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
    }
}