using iikoTest.Services.Interfaces;
using iikoTest.Services.Models;
using iikoTest.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace iikoTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService) =>
            _clientsService = clientsService;

        [HttpGet]
        public async Task<List<Client>> Get() =>
            await _clientsService.GetAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> Get(long id)
        {
            var client = await _clientsService.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return new ObjectResult(client);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Client updatedClient)
        {
            await _clientsService.UpdateAsync(updatedClient);
            return Ok(updatedClient);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var client = await _clientsService.GetByIdAsync(id);

            await _clientsService.RemoveAsync(client);
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<List<Client>>> CreateMany([FromBody]IEnumerable<Client> clients)
        {
            //return already existing by id items from request
            var existingClients = await _clientsService.CreateUniqueMany(clients);
            if(existingClients is null)
            {
                return BadRequest("Should be at least 10 elements");
            }
            return new ObjectResult(existingClients);
        }
    }
}
