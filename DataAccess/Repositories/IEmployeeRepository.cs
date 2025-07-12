using BusinessObjects.Models;

namespace DataAccess.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee? Login(string username, string password);
    }
}