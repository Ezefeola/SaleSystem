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
    public class ClientMappers : IClientMappers
    {
        public ClientResponseDTO MapToResponseDTO(ClientRequestDTO requestDto)
        {
            return new ClientResponseDTO
            {
                Client = requestDto.Client,
                PhoneNumber = requestDto.PhoneNumber,
                EmailAddress = requestDto.EmailAddress
            };
        }

        public ClientRequestDTO MapToRequestDTO(ClientResponseDTO responseDto)
        {
            return new ClientRequestDTO
            {
                Client = responseDto.Client,
                PhoneNumber = responseDto.PhoneNumber,
                EmailAddress = responseDto.EmailAddress
            };
        }
    }
}