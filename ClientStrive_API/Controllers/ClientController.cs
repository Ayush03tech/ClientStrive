using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using ClientStrive_API.Data;
using ClientStrive_API.QueryHandler;
using ClientStrive_API.QueryHandler.GetAllClient.delete;
using ClientStrive_API.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace ClientStrive_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("GetAllClients")]
        public async Task<IActionResult> GetAllClients()
        {
            try
            {
                var query = new GetAllClientQuery();
                var AllClients = await _mediator.Send(query);
                return Ok(APIResponse.Success(AllClients));
            }
            catch (Exception ex)
            {
                return BadRequest(APIResponse.Failure($"An error occurred: {ex.Message}"));
            }
        }

        [HttpPost("AddUpdateClient")]
        public async Task<IActionResult> AddUpdateClient([FromBody] ClientDto clientDto) { 

            var query = new CreateClientQuery(clientDto);
            var result  = await _mediator.Send(query);
            var message = clientDto.clientId == 0 ? "Client Created successfully" : "Client Updated successfully";
            if (result != null)
            {
                return Ok(APIResponse.Success(message,result));
            }
            else
            {
                return BadRequest(APIResponse.Failure("Failed to add/update client."));
            }
        }

        [HttpDelete("DeleteClientbyClientId")]
        public async Task<IActionResult> DeleteClientbyClientId([FromQuery] int clientId)
        {
            var query = new DeleteClientCommand(clientId);
            var result = await _mediator.Send(query);
            if (result)
            {
                return Ok(APIResponse.Success("Client deleted successfully", null));
            }
            else
            {
                return BadRequest(APIResponse.Failure("Failed to delete client."));
            }
        }
    }
}
