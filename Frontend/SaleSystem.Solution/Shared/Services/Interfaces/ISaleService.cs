using Shared.DTOs.Request;
using Shared.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.Interfaces
{
    public interface ISaleService
    {
        Task<List<SaleResponseDTO>> GetSales();
        Task<SaleResponseDTO> GetSaleById(int id);
        Task CreateSale(SaleRequestDTO saleRequestDTO);
        Task UpdateSale(int id, SaleRequestDTO saleRequestDTO);
        Task DeleteSale(int id);
    }
}
