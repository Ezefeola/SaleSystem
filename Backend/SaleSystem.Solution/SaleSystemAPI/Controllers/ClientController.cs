using Microsoft.AspNetCore.Mvc;
using SaleSystemAPI.DTOs.Request;
using SaleSystemAPI.Repositories.Interfaces;
using SaleSystemAPI.Utilities.Mappers;

namespace SaleSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet()]
        public async Task<IActionResult> GetClients()
        {
            try
            {
                var clients = await _clientRepository.GetAll();

                return Ok(clients);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            try
            {
                var client = await _clientRepository.GetById(id);

                return Ok(client);
            }
            catch (Exception)
            {

                return NotFound(id);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateClient([FromBody] ClientRequestDTO clientRequestDTO)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var client = clientRequestDTO.FromRequestDtoToModel();

                var createdClient = await _clientRepository.Create(client);

                return Ok(createdClient.FromModelToResponseDto());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("Update/{id:int}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientRequestDTO clientRequestDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var clientToUpdate = clientRequestDTO.FromRequestDtoToModel();

                var updatedClient = await _clientRepository.Update(id, clientToUpdate);

                return Ok(updatedClient.FromModelToResponseDto());
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            try
            {
                var deletedClient = await _clientRepository.Delete(id);

                return Ok(deletedClient);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
