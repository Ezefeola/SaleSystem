using SaleSystemAPI.Data;
using SaleSystemAPI.Models;
using SaleSystemAPI.Repositories.Interfaces;

namespace SaleSystemAPI.Repositories.Classes
{
    public class SaleRepository : GenericRepository<SaleModel>, ISaleRepository
    {
        public SaleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
