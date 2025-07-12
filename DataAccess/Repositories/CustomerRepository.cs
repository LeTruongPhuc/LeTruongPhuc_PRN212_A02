using BusinessObjects;
using BusinessObjects.Models;
using System.Linq;

namespace DataAccess.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LucySalesDbContext context) : base(context)
        {
        }

        public Customer? GetCustomerByPhone(string phone)
        {
            return _context.Customers.FirstOrDefault(c => c.Phone == phone);
        }
    }
}