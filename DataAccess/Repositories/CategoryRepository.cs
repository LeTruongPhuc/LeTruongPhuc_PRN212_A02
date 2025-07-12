using BusinessObjects;
using BusinessObjects.Models;

namespace DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(LucySalesDbContext context) : base(context)
        {
        }

        // Add any specific implementation for Category repository
    }
}