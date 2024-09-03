using Shared.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.Classes
{
    public class GenericService<T, TKey> : IGenericService<T, TKey> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpointUrl;

        public GenericService(HttpClient httpClient, string endpointUrl)
        {
            _httpClient = httpClient;
            _endpointUrl = endpointUrl;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<T>>(_endpointUrl);
            return response ?? new List<T>();
        }

        public async Task<T?> GetByIdAsync(TKey id)
        {
            var response = await _httpClient.GetAsync($"{_endpointUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            return null;
        }

        public async Task<bool> CreateAsync(T entity)
        {
            var response = await _httpClient.PostAsJsonAsync(_endpointUrl, entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(TKey id, T entity)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_endpointUrl}/{id}", entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            var response = await _httpClient.DeleteAsync($"{_endpointUrl}/{id}");
            return response.IsSuccessStatusCode;
        }
    }

}
