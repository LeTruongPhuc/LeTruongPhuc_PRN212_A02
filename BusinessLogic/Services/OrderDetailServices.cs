using BusinessObjects.Models;
using DataAccess;
using DataAccess.Repositories;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _repository;

        public OrderDetailService()
        {
            _repository = RepositoryFactory.Instance.CreateOrderDetailRepository();
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByOrder(int orderId)
        {
            return _repository.GetOrderDetailsByOrder(orderId);
        }
    }
}