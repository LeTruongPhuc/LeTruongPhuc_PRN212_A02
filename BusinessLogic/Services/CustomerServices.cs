using BusinessObjects.Models;
using DataAccess;
using DataAccess.Repositories;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService()
        {
            _repository = RepositoryFactory.Instance.CreateCustomerRepository();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _repository.GetAll();
        }

        public Customer? GetCustomerById(string id)
        {
            return _repository.GetById(id);
        }

        public Customer? GetCustomerByPhone(string phone)
        {
            return _repository.GetCustomerByPhone(phone);
        }

        public void AddCustomer(Customer customer)
        {
            _repository.Add(customer);
            _repository.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _repository.Update(customer);
            _repository.SaveChanges();
        }

        public void DeleteCustomer(string id)
        {
            _repository.Remove(id);
            _repository.SaveChanges();
        }
    }
}