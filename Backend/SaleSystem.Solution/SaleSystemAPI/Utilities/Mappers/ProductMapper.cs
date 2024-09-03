using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SaleSystemAPI.DTOs.Request;
using SaleSystemAPI.DTOs.Response;
using SaleSystemAPI.Models;

namespace SaleSystemAPI.Utilities.Mappers
{
    public static class ProductMapper
    {
        public static ProductModel FromRequestDtoToModel(this ProductRequestDTO productRequestDTO)
        {
            return new ProductModel
            {
                Name = productRequestDTO.Name,
                Description = productRequestDTO.Description,
                Price = productRequestDTO.Price,
                CategoryId = productRequestDTO.CategoryId,
            };
        }

        public static ProductResponseDTO FromModelToResponseDto(this ProductModel productModel)
        {
            return new ProductResponseDTO
            {
                Name = productModel.Name,
                Description = productModel.Description,
                Price = productModel.Price,
                CategoryId = productModel.CategoryId,
            };
        }
    }
}
