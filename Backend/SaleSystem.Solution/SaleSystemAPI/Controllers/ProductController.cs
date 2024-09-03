using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleSystemAPI.DTOs.Request;
using SaleSystemAPI.Repositories.Interfaces;
using SaleSystemAPI.Utilities.Mappers;
using System.Runtime.CompilerServices;

namespace SaleSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _productRepository.GetAll();

                return Ok(products);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var product = await _productRepository.GetById(id);

                return Ok(product);
            }
            catch (Exception)
            {

                return NotFound(id);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct(ProductRequestDTO productRequestDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var productToCreate = productRequestDTO.FromRequestDtoToModel();

                var createdProduct = await _productRepository.Create(productToCreate);

                return Ok(createdProduct.FromModelToResponseDto());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductRequestDTO productRequestDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var productToUpdate = productRequestDTO.FromRequestDtoToModel();

                var updatedProduct = await _productRepository.Update(id, productToUpdate);

                return Ok(updatedProduct.FromModelToResponseDto());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var deletedProduct = await _productRepository.Delete(id);

                return Ok(deletedProduct);
            }
            catch (Exception)
            {

                return BadRequest(id);
            }
        }
    }
}
