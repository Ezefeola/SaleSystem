using Microsoft.OpenApi.Any;
using SaleSystemAPI.Models;

namespace SaleSystemAPI.Repositories.Interfaces
{
    public interface ISaleRepository : IGenericRepository<SaleModel>
    {
        Task<SaleModel> GetSaleByIdAsync(int id);
        Task<List<int>> GetSaleItemIdAsync(int id);
        Task<SaleModel> UpdateSale(int id, SaleModel saleModel);
    }
}
