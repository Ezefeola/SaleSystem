using SaleSystemAPI.DTOs.Request;
using SaleSystemAPI.DTOs.Response;
using SaleSystemAPI.Models;

namespace SaleSystemAPI.Utilities.Mappers
{
    public static class SaleMapper
    {

        public static SaleModel FromRequestDtoToModel(this SaleRequestDTO saleRequestDTO)
        {
            return new SaleModel
            {
                ClientId = saleRequestDTO.ClientId,
                Date = DateTime.Now,
                SaleItemModel = saleRequestDTO.SaleItemModel.Select(item => new SaleItemModel
                {
                    ProductId = item.ProductId,
                    PricePerUnit = item.PricePerUnit,
                    Quantity = item.Quantity,
                    TotalPrice = item.PricePerUnit * item.Quantity
                }).ToList(),
                Total = saleRequestDTO.SaleItemModel.Sum(i => i.PricePerUnit * i.Quantity)
            };
        }

        public static SaleModel FromRequestDtoToModelToUpdate(this SaleRequestDTO saleRequestDTO, int id, List<int> saleItemIds)
        { 
            return new SaleModel
            {
                ClientId = saleRequestDTO.ClientId,
                Date = DateTime.Now,
                SaleItemModel = saleRequestDTO.SaleItemModel.Select((item, index) => new SaleItemModel
                {
                    Id = saleItemIds.ElementAtOrDefault(index),
                    SaleId = id,
                    ProductId = item.ProductId,
                    PricePerUnit = item.PricePerUnit,
                    Quantity = item.Quantity,
                    TotalPrice = item.PricePerUnit * item.Quantity
                }).ToList(),
                Total = saleRequestDTO.SaleItemModel.Sum(i => i.PricePerUnit * i.Quantity)
            };
        }

        public static SaleResponseDTO FromModelToResponseDto(this SaleModel model)
        {
            return new SaleResponseDTO
            {
                Id = model.Id,
                ClientId = model.ClientId,
                Date = model.Date,
                Total = model.Total,
                SaleItemModel = model.SaleItemModel.Select(item => new SaleItemResponseDTO
                {
                    ProductId = item.ProductId,
                    PricePerUnit = item.PricePerUnit,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice
                }).ToList()
            };
        }
    }
}
