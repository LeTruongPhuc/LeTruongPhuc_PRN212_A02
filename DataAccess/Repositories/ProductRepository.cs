using BusinessObjects;
using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(LucySalesDbContext context) : base(context)
        {
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products
                .Where(p => p.CategoryID == categoryId)
                .Include(p => p.Category)
                .ToList();
        }

        public IEnumerable<Product> GetProductsInStock()
        {
            return _context.Products
                .Where(p => p.UnitsInStock > 0 && !p.Discontinued)
                .Include(p => p.Category)
                .ToList();
        }
    }
}