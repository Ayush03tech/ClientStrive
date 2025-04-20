using ClientStrive_API.Data;
using ClientStrive_API.QueryHandler.GetAllEmployee;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientStrive_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public EmployeeController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _mediator.Send(new GetAllEmployeeQuery());
            return Ok(APIResponse.Success("Employees retrieved successfully", employees));
        }
    }
}
