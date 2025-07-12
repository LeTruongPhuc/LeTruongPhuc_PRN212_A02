using BusinessObjects.Models;
using DataAccess;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;

        public OrderService()
        {
            _orderRepository = RepositoryFactory.Instance.CreateOrderRepository();
            _orderDetailRepository = RepositoryFactory.Instance.CreateOrderDetailRepository();
            _productRepository = RepositoryFactory.Instance.CreateProductRepository();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        public Order? GetOrderById(int id)
        {
            return _orderRepository.GetById(id);
        }

        public IEnumerable<Order> GetOrdersByCustomer(string customerId)
        {
            return _orderRepository.GetOrdersByCustomer(customerId);
        }

        public IEnumerable<Order> GetOrdersByDateRange(DateTime startDate, DateTime endDate)
        {
            return _orderRepository.GetOrdersByDateRange(startDate, endDate);
        }

        public void AddOrder(Order order, IEnumerable<OrderDetail> orderDetails)
        {
            using (var transaction = _orderRepository.Context.Database.BeginTransaction())
            {
                try
                {
                    _orderRepository.Add(order);
                    _orderRepository.SaveChanges();

                    foreach (var detail in orderDetails)
                    {
                        detail.OrderID = order.OrderID;
                        _orderDetailRepository.Add(detail);

                        // Update product stock
                        var product = _productRepository.GetById(detail.ProductID);
                        if (product != null)
                        {
                            product.UnitsInStock = (short)(product.UnitsInStock - detail.Quantity);
                            _productRepository.Update(product);
                        }
                    }

                    _orderDetailRepository.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void UpdateOrder(Order order)
        {
            _orderRepository.Update(order);
            _orderRepository.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            _orderRepository.Remove(id);
            _orderRepository.SaveChanges();
        }
    }
}