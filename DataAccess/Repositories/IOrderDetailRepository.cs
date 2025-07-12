using BusinessObjects.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        IEnumerable<OrderDetail> GetOrderDetailsByOrder(int orderId);
    }
}