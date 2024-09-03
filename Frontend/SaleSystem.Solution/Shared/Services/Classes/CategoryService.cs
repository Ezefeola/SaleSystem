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
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("SaleSystemApi");
        }
        public async Task<List<CategoryResponseDTO>> GetCategories()
        {
            return await _httpClient.GetFromJsonAsync<List<CategoryResponseDTO>>("Category");
        }

        public async Task<CategoryResponseDTO> GetCategoryById(int id)
        {
            return await _httpClient.GetFromJsonAsync<CategoryResponseDTO>($"Category/{id}");
        }

        public async Task CreateCategory(CategoryRequestDTO categoryRequestDTO)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("Category/Create", categoryRequestDTO);

                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    // Log or handle the error message as needed
                    throw new HttpRequestException($"Error creating category: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task UpdateCategory(int id, CategoryRequestDTO categoryRequestDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"Category/Update/{id}", categoryRequestDTO);

            if (!response.IsSuccessStatusCode)
            {
                // Manejar el error si la respuesta no es exitosa
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error al actualizar la categoria: {errorContent}");
            }

        }

        public async Task DeleteCategory(int id)
        {
            var response = await _httpClient.DeleteAsync($"Category/Delete/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
