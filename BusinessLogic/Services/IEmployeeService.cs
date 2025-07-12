using BusinessObjects.Models;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee? GetEmployeeById(int id);
        Employee? Login(string username, string password);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int id);
    }
}