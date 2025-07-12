using BusinessObjects.Models;
using System.Windows;

namespace LeTruongPhucWPF.Views
{
    public partial class CustomerDashboard : Window
    {
        private readonly Customer _currentCustomer;

        public CustomerDashboard(Customer customer)
        {
            InitializeComponent();
            _currentCustomer = customer;
            Title = $"Customer Dashboard - Welcome {_currentCustomer.CompanyName}";
        }
    }
}