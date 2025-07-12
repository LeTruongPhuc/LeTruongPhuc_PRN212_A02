using BusinessLogic.Services;
using BusinessObjects.Models;
using System;
using System.Windows;
using System.Windows.Input;
using LeTruongPhucWPF.Commands;

namespace LeTruongPhucWPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICustomerService _customerService;

        private string _username = string.Empty;
        private string _password = string.Empty;
        private bool _isAdmin = true;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public bool IsAdmin
        {
            get => _isAdmin;
            set => SetProperty(ref _isAdmin, value);
        }

        public ICommand LoginCommand { get; }

        public event Action<Employee>? AdminLoginSuccess;
        public event Action<Customer>? CustomerLoginSuccess;

        public LoginViewModel()
        {
            _employeeService = new EmployeeService();
            _customerService = new CustomerService();

            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        private bool CanExecuteLogin(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void ExecuteLogin(object? parameter)
        {
            try
            {
                if (IsAdmin)
                {
                    var employee = _employeeService.Login(Username, Password);
                    if (employee != null)
                    {
                        AdminLoginSuccess?.Invoke(employee);
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    var customer = _customerService.GetCustomerByPhone(Username);
                    if (customer != null && customer.Phone == Password)
                    {
                        CustomerLoginSuccess?.Invoke(customer);
                    }
                    else
                    {
                        MessageBox.Show("Invalid phone number or password!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}