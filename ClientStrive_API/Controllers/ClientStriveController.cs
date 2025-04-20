using ClientStrive_API.Data;
using ClientStrive_API.Models.Entities;
using ClientStrive_API.QueryHandler.GetAllDesignation;
using ClientStrive_API.QueryHandler.GetRole;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientStrive_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientStriveController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ClientStriveController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles(){
            var Allroles  = await _mediator.Send(new GetAllRoleQuery());
            return Ok(APIResponse.Success(Allroles));
        }

        [HttpGet("GetRoleById")]
        public async Task<IActionResult> GetRoleById(int id){
            var result = await _mediator.Send(new GetAllRoleQuery(id));
            return Ok(APIResponse.Success(result));
        }

        [HttpGet("GetAllDesignations")]
        public async Task<IActionResult> GetAllDesignations(){
            var result = await _mediator.Send(new GetAllDesignationQuery());
            return Ok(APIResponse.Success(result));
        }
    }
}
