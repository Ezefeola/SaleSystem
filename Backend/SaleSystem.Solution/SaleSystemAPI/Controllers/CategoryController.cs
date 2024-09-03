using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleSystemAPI.DTOs.Request;
using SaleSystemAPI.Repositories.Interfaces;
using SaleSystemAPI.Utilities.Mappers;

namespace SaleSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetAll();

                return Ok(categories);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryRepository.GetById(id);

                return Ok(category);
            }
            catch (Exception)
            {

                return NotFound(id);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCategory(CategoryRequestDTO categoryRequestDTO)
        {
            var category = categoryRequestDTO.FromRequestDtoToModel();

            var createdCategory = await _categoryRepository.Create(category);

            return Ok(createdCategory.FromModelToResponseDto());
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryRequestDTO categoryRequestDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var categoryToUpdate = categoryRequestDTO.FromRequestDtoToModel();

                var updatedCategory = await _categoryRepository.Update(id, categoryToUpdate);

                return Ok(updatedCategory.FromModelToResponseDto());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var deletedCategory = await _categoryRepository.Delete(id);

                return Ok(deletedCategory);
            }
            catch (Exception)
            {

                return BadRequest(new Exception());
            }
        }
    }
}
