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
    public class CategoryMappers : ICategoryMappers
    {
        public CategoryResponseDTO MapToResponseDTO(CategoryRequestDTO categoryRequestDTO)
        {
            return new CategoryResponseDTO
            {
                Name = categoryRequestDTO.Name,

            };
        }

        public CategoryRequestDTO MapToRequestDTO(CategoryResponseDTO categoryResponseDTO)
        {
            return new CategoryRequestDTO
            {
                Name = categoryResponseDTO.Name,
            };
        }
    }
}
