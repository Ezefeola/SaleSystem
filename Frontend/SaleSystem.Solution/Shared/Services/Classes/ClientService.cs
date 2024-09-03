using Shared.DTOs.Request;
using Shared.DTOs.Response;
using Shared.Models;
using Shared.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;


namespace Shared.Services.Classes
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SaleSystemApi");
        }
        public async Task<List<ClientResponseDTO>> GetClients()
        {
            return await _httpClient.GetFromJsonAsync<List<ClientResponseDTO>>("Client");
        }

        public async Task<ClientResponseDTO> GetClientById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ClientResponseDTO>($"Client/{id}");
        }

        public async Task CreateClient(ClientRequestDTO clientRequestDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Client/Create", clientRequestDTO);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    // Log or handle the error message as needed
                    throw new HttpRequestException($"Error creating client: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task UpdateClient(int id, ClientRequestDTO clientRequestDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"Client/Update/{id}", clientRequestDTO);

            if (!response.IsSuccessStatusCode)
            {
                // Manejar el error si la respuesta no es exitosa
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar el cliente: {errorContent}");
            }

        }

        public async Task DeleteClient(int id)
        {
            var response = await _httpClient.DeleteAsync($"Client/Delete/{id}");
            response.EnsureSuccessStatusCode();
        }


    }
}
