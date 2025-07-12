using BusinessObjects.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public interface IOrderDetailService
    {
        IEnumerable<OrderDetail> GetOrderDetailsByOrder(int orderId);
    }
}