using BusinessObjects.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer? GetCustomerByPhone(string phone);
    }
}