using Shared.DTOs.Request;
using Shared.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utilities.Mappers.Interfaces
{
    public interface ISaleMappers
    {
        SaleResponseDTO MapToResponseDTO(SaleRequestDTO saleRequestDTO);
        SaleRequestDTO MapToRequestDTO(SaleResponseDTO saleResponseDTO);
        SaleItemResponseDTO MapToItemResponseDTO(SaleItemRequestDTO saleItemRequestDTO);
    }
}
