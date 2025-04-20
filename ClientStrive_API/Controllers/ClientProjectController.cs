using ClientStrive_API.Data;
using ClientStrive_API.Models.Entities;
using ClientStrive_API.QueryHandler.GetAllClientProject;
using ClientStrive_API.QueryHandler.GetAllClientProject.delete;
using ClientStrive_API.QueryHandler.GetAllClientProject.post;
using ClientStrive_API.QueryHandler.GetProject;
using ClientStrive_API.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientStrive_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientProjectController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ClientProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("GetAllClientProjects")]
        public async Task<IActionResult> GetAllClientProjects()
        {
            var allProject = await _mediator.Send(new GetAllClientProjectQuery());
            return Ok(APIResponse.Success("Project created successfully",allProject));
        }

        [HttpGet("GetProjectByProjectId")]
        public async Task<IActionResult> GetProjectByProjectId([FromQuery] int clientProjectId)
        {
            var query = new GetProjectQuery(clientProjectId);
            var result = await _mediator.Send(query);
            if (result != null)
            {
                return Ok(APIResponse.Success("Client Project fetched successfully", result));
            }
            else
            {
                return BadRequest(APIResponse.Failure("Failed to fetch client project."));
            }
        }

        [HttpPost("AddUpdateClientProject")]
        public async Task<IActionResult> AddUpdateClientProject([FromBody] ClientProjectDto clientProjectDto)
        {
            var query = new ClientProjectCommand(clientProjectDto);
            var result = await _mediator.Send(query);
            var message = clientProjectDto.ClientProjectId == 0 ? "Client Project Created successfully" : "Client Project Updated successfully";
            if (result != null)
            {
                return Ok(APIResponse.Success(message, result));
            }
            else
            {
                return BadRequest(APIResponse.Failure("Failed to add/update client project."));
            }
        }

        [HttpDelete("DeleteClientProjectById")]
        public async Task<IActionResult> DeleteClientProjectById([FromQuery] int projectId)
        {
            var query = new DeleteClientProjectCommand(projectId);
            var result = await _mediator.Send(query);
            if (result)
            {
                return Ok(APIResponse.Success("Client Project deleted successfully", result));
            }
            else
            {
                return BadRequest(APIResponse.Failure("Failed to delete client project."));
            }
        }
        
    }
}
