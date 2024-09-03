using SaleSystemAPI.Data;
using SaleSystemAPI.Models;
using SaleSystemAPI.Repositories.Interfaces;

namespace SaleSystemAPI.Repositories.Classes
{
    public class ProductRepository : GenericRepository<ProductModel>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
