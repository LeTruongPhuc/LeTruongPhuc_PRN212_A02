using BusinessLogic.Services;
using BusinessObjects.Models;
using LeTruongPhucWPF.Views;
using System.Windows;

namespace LeTruongPhucWPF
{
    public partial class MainWindow : Window
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICustomerService _customerService;

        public MainWindow()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _customerService = new CustomerService();
        }

        private void AdminLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = AdminUsername.Text;
            string password = AdminPassword.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Employee employee = _employeeService.GetEmployeeByCredentials(username, password);

            if (employee != null)
            {
                AdminDashboard dashboard = new AdminDashboard(employee);
                dashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CustomerLogin_Click(object sender, RoutedEventArgs e)
        {
            string phone = CustomerPhone.Text;
            string password = CustomerPassword.Password;

            if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both phone and password", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Customer customer = _customerService.GetCustomerByCredentials(phone, password);

            if (customer != null)
            {
                CustomerDashboard dashboard = new CustomerDashboard(customer);
                dashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid phone or password", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}