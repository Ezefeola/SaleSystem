using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaleSystemAPI.DTOs.Request;
using SaleSystemAPI.Repositories.Interfaces;
using SaleSystemAPI.Utilities.Mappers;

namespace SaleSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetSales()
        {
            var sales = await _saleRepository.GetAll();

            return Ok(sales);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSaleById(int id)
        {
            try
            {
                var sale = await _saleRepository.GetSaleByIdAsync(id);

                if (sale is null) return NotFound($"El id: {id} no se encontro");

                return Ok(sale);
            }
            catch (Exception)
            {

                return BadRequest(new Exception());
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateSale(SaleRequestDTO saleRequestDTO)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var saleToCreate = saleRequestDTO.FromRequestDtoToModel();

                var createdSale = await _saleRepository.Create(saleToCreate);

                return Ok(createdSale.FromModelToResponseDto());
            }
            catch (Exception)
            {

                return BadRequest(new Exception());
            }
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateSale(int id, SaleRequestDTO saleRequestDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                // Obtener los IDs de los SaleItems relacionados con la venta
                var saleItemIds = await _saleRepository.GetSaleItemIdAsync(id);

                // Convertir el DTO al modelo de venta usando la lista de IDs
                var saleToUpdate = saleRequestDTO.FromRequestDtoToModelToUpdate(id, saleItemIds);

                // Actualizar la venta en la base de datos
                var updatedSale = await _saleRepository.UpdateSale(id, saleToUpdate);

                return Ok(updatedSale.FromModelToResponseDto());
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error al actualizar la venta.", Exception = ex.Message });
            }
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteSale(int id)
        {
            try
            {
                var saleToDelete = await _saleRepository.Delete(id);

                if (saleToDelete is null) return NotFound(id);

                return Ok(saleToDelete);
            }
            catch (Exception)
            {

                return BadRequest(new Exception());
            }
        }
    }
}
