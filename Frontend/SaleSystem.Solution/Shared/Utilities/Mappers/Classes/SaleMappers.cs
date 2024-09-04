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
    public class SaleMappers : ISaleMappers
    {
        public SaleResponseDTO MapToResponseDTO(SaleRequestDTO saleRequestDTO)
        {
            return new SaleResponseDTO
            {
                ClientId = saleRequestDTO.ClientId,
                Date = saleRequestDTO.Date,
                SaleItemModel = saleRequestDTO.SaleItemModel.Select(MapToItemResponseDTO).ToList(), 
            };
        }

        public SaleRequestDTO MapToRequestDTO(SaleResponseDTO saleResponseDTO)
        {
            return new SaleRequestDTO
            {

            };
        }

        public SaleItemResponseDTO MapToItemResponseDTO(SaleItemRequestDTO saleItemRequestDTO)
        {
            return new SaleItemResponseDTO
            {
                ProductId = saleItemRequestDTO.ProductId,
                Quantity = saleItemRequestDTO.Quantity,
                PricePerUnit = saleItemRequestDTO.PricePerUnit
            };
        }
    }
}
