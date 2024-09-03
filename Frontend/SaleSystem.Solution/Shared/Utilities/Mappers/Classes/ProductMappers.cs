using Shared.DTOs.Request;
using Shared.DTOs.Response;
using Shared.Utilities.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utilities.Mappers.Classes
{
    public class ProductMappers : IProductMappers
    {
        public ProductResponseDTO MapToResponseDTO(ProductRequestDTO productRequestDto)
        {
            return new ProductResponseDTO
            {
                Name = productRequestDto.Name,
                CategoryId = productRequestDto.CategoryId,
                Description = productRequestDto.Description,
                Price = productRequestDto.Price,
            };
        }

        public ProductRequestDTO MapToRequestDTO(ProductResponseDTO productResponseDTO)
        {
            return new ProductRequestDTO
            {
                Name = productResponseDTO.Name,
                CategoryId = productResponseDTO.CategoryId,
                Description = productResponseDTO.Description,
                Price = productResponseDTO.Price,
            };
        }
    }
}
