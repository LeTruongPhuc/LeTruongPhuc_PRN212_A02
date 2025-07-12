using BusinessObjects.Models;
using DataAccess;
using DataAccess.Repositories;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService()
        {
            _repository = RepositoryFactory.Instance.CreateEmployeeRepository();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _repository.GetAll();
        }

        public Employee? GetEmployeeById(int id)
        {
            return _repository.GetById(id);
        }

        public Employee? Login(string username, string password)
        {
            return _repository.Login(username, password);
        }

        public void AddEmployee(Employee employee)
        {
            _repository.Add(employee);
            _repository.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _repository.Update(employee);
            _repository.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            _repository.Remove(id);
            _repository.SaveChanges();
        }
    }
}