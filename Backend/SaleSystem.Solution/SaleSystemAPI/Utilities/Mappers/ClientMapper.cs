using SaleSystemAPI.DTOs.Request;
using SaleSystemAPI.DTOs.Response;
using SaleSystemAPI.Models;

namespace SaleSystemAPI.Utilities.Mappers
{
    public static class ClientMapper
    {
        public static ClientModel FromRequestDtoToModel(this ClientRequestDTO clientRequestDTO)
        {
            return new ClientModel
            {
                Client = clientRequestDTO.Client,
                PhoneNumber = clientRequestDTO.PhoneNumber,
                EmailAddress = clientRequestDTO.EmailAddress,
            };
        }

        public static ClientResponseDTO FromModelToResponseDto(this ClientModel clientModel)
        {
            return new ClientResponseDTO
            {
                Client = clientModel.Client,
                PhoneNumber = clientModel.PhoneNumber,
                EmailAddress = clientModel.EmailAddress,
            };
        }
    }
}
