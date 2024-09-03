using Shared.DTOs.Request;
using Shared.DTOs.Response;
using Shared.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.Classes
{
    public class SaleService : ISaleService
    {
        private readonly HttpClient _httpClient;

        public SaleService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SaleSystemApi");
        }
        public async Task<List<SaleResponseDTO>> GetSales()
        {
            return await _httpClient.GetFromJsonAsync<List<SaleResponseDTO>>("Sale");
        }

        public async Task<SaleResponseDTO> GetSaleById(int id)
        {
            return await _httpClient.GetFromJsonAsync<SaleResponseDTO>($"Sale/{id}");
        }


        public async Task CreateSale(SaleRequestDTO saleRequestDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Sale/Create", saleRequestDTO);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    // Log or handle the error message as needed
                    throw new HttpRequestException($"Error creating sale: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task UpdateSale(int id, SaleRequestDTO saleRequestDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"Sale/Update/{id}", saleRequestDTO);

            if (!response.IsSuccessStatusCode)
            {
                // Manejar el error si la respuesta no es exitosa
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error Updating sale: {errorContent}");
            }
        }
        public async Task DeleteSale(int id)
        {
            var response = await _httpClient.DeleteAsync($"Sale/Delete/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
