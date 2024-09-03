using Shared.DTOs.Request;
using Shared.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utilities.Mappers.Interfaces
{
    public interface IProductMappers
    {
        ProductResponseDTO MapToResponseDTO(ProductRequestDTO ProductRequestDto);
        ProductRequestDTO MapToRequestDTO(ProductResponseDTO productResponseDto);
    }
}
