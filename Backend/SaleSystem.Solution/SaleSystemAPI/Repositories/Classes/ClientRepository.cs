using SaleSystemAPI.Data;
using SaleSystemAPI.Models;
using SaleSystemAPI.Repositories.Interfaces;

namespace SaleSystemAPI.Repositories.Classes
{
    public class ClientRepository : GenericRepository<ClientModel>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
