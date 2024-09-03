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
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SaleSystemApi");
        }
        public async Task<List<ProductResponseDTO>> GetProducts()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductResponseDTO>>("Product");
        }

        public async Task<ProductResponseDTO> GetProductById(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProductResponseDTO>($"Product/{id}");
        }

        public async Task CreateProduct(ProductRequestDTO productRequestDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Product/Create", productRequestDTO);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    // Log or handle the error message as needed
                    throw new HttpRequestException($"Error al crear el producto: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"Hubo un error: {ex.Message}");
            }
        }

        public async Task UpdateProduct(int id, ProductRequestDTO productRequestDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"Product/Update/{id}", productRequestDTO);

            if (!response.IsSuccessStatusCode)
            {
                // Manejar el error si la respuesta no es exitosa
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar el producto: {errorContent}");
            }

        }

        public async Task DeleteProduct(int id)
        {
            var response = await _httpClient.DeleteAsync($"Product/Delete/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
