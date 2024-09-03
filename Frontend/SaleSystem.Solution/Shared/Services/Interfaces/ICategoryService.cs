using Shared.DTOs.Request;
using Shared.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDTO>> GetCategories();
        Task<CategoryResponseDTO> GetCategoryById(int id);
        Task CreateCategory(CategoryRequestDTO categoryRequestDTO);
        Task UpdateCategory(int id, CategoryRequestDTO categoryRequestDTO);
        Task DeleteCategory(int id);
    }
}
