using System.Windows;
using LeTruongPhucWPF.ViewModels;
using BusinessObjects.Models;

namespace LeTruongPhucWPF.Views
{
    public partial class LoginView : Window
    {
        private readonly LoginViewModel _viewModel;

        public LoginView()
        {
            InitializeComponent();

            _viewModel = new LoginViewModel();
            DataContext = _viewModel;

            PasswordBox.PasswordChanged += PasswordBox_PasswordChanged;

            _viewModel.AdminLoginSuccess += ViewModel_AdminLoginSuccess;
            _viewModel.CustomerLoginSuccess += ViewModel_CustomerLoginSuccess;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = PasswordBox.Password;
        }

        private void ViewModel_AdminLoginSuccess(Employee employee)
        {
            // TODO: Open Admin Dashboard
            var adminDashboard = new AdminDashboard(employee);
            adminDashboard.Show();
            this.Close();
        }

        private void ViewModel_CustomerLoginSuccess(Customer customer)
        {
            // TODO: Open Customer Dashboard
            var customerDashboard = new CustomerDashboard(customer);
            customerDashboard.Show();
            this.Close();
        }
    }
}