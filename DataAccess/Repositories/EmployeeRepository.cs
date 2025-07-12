using BusinessObjects;
using BusinessObjects.Models;
using System.Linq;

namespace DataAccess.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(LucySalesDbContext context) : base(context)
        {
        }

        public Employee? Login(string username, string password)
        {
            return _context.Employees
                .FirstOrDefault(e => e.UserName == username && e.Password == password);
        }
    }
}