using SaleSystemAPI.Data;
using SaleSystemAPI.Models;
using SaleSystemAPI.Repositories.Interfaces;

namespace SaleSystemAPI.Repositories.Classes
{
    public class CategoryRepository : GenericRepository<CategoryModel>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
