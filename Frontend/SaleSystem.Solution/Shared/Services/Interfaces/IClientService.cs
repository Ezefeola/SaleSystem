using Shared.DTOs.Request;
using Shared.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientResponseDTO>> GetClients();
        Task<ClientResponseDTO> GetClientById(int id);
        Task CreateClient(ClientRequestDTO clientRequestDTO);
        Task UpdateClient(int id, ClientRequestDTO clientRequestDTO);
        Task DeleteClient(int id);
    }
}
