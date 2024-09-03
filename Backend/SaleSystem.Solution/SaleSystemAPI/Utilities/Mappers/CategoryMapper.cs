using SaleSystemAPI.DTOs.Request;
using SaleSystemAPI.DTOs.Response;
using SaleSystemAPI.Models;

namespace SaleSystemAPI.Utilities.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryModel FromRequestDtoToModel(this CategoryRequestDTO categoryRequestDTO)
        {
            return new CategoryModel
            {
                Name = categoryRequestDTO.Name,
            };
        }

        public static CategoryResponseDTO FromModelToResponseDto(this CategoryModel categoryModel)
        {
            return new CategoryResponseDTO
            {
                Name = categoryModel.Name,
            };
        }
    }
}
