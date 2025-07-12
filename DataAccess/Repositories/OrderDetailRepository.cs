using BusinessObjects;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(LucySalesDbContext context) : base(context)
        {
        }

        public IEnumerable<OrderDetail> GetOrderDetailsByOrder(int orderId)
        {
            return _context.OrderDetails
                .Where(od => od.OrderID == orderId)
                .Include(od => od.Product)
                .ToList();
        }
    }
}