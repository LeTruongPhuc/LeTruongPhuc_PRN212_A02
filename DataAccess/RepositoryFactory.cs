using BusinessObjects;
using DataAccess.Repositories;

namespace DataAccess
{
    public class RepositoryFactory
    {
        private static RepositoryFactory? _instance;
        private static readonly object _lock = new object();
        private readonly LucySalesDbContext _context;

        private RepositoryFactory()
        {
            _context = DbContextUtilities.GetDbContext();
        }

        public static RepositoryFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new RepositoryFactory();
                        }
                    }
                }
                return _instance;
            }
        }

        public ICategoryRepository CreateCategoryRepository()
        {
            return new CategoryRepository(_context);
        }

        public IProductRepository CreateProductRepository()
        {
            return new ProductRepository(_context);
        }

        public ICustomerRepository CreateCustomerRepository()
        {
            return new CustomerRepository(_context);
        }

        public IEmployeeRepository CreateEmployeeRepository()
        {
            return new EmployeeRepository(_context);
        }

        public IOrderRepository CreateOrderRepository()
        {
            return new OrderRepository(_context);
        }

        public IOrderDetailRepository CreateOrderDetailRepository()
        {
            return new OrderDetailRepository(_context);
        }
    }
}