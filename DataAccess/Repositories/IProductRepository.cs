using BusinessObjects.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetProductsByCategory(int categoryId);
        IEnumerable<Product> GetProductsInStock();
    }
}