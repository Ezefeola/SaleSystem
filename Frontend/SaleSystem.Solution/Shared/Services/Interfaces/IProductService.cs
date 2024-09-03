using Shared.DTOs.Request;
using Shared.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductResponseDTO>> GetProducts();
        Task<ProductResponseDTO> GetProductById(int id);
        Task CreateProduct(ProductRequestDTO productRequestDTO);
        Task UpdateProduct(int id, ProductRequestDTO productRequestDTO);
        Task DeleteProduct(int id);
    }
}
