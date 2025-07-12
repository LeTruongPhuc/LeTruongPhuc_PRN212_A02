using BusinessObjects.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer? GetCustomerById(string id);
        Customer? GetCustomerByPhone(string phone);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(string id);
    }
}