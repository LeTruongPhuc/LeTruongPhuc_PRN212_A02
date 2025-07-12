using BusinessObjects.Models;
using System.Windows;

namespace LeTruongPhucWPF.Views
{
    public partial class AdminDashboard : Window
    {
        private readonly Employee _currentEmployee;

        public AdminDashboard(Employee employee)
        {
            InitializeComponent();
            _currentEmployee = employee;
            Title = $"Admin Dashboard - Welcome {_currentEmployee.Name}";
        }
    }
}