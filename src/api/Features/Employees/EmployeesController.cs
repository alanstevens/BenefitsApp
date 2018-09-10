using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Paylocity.API.Features.Employees
{
    [ApiController]
    public class ApiController : Controller
    {
        public ApiController(IMediator mediator) { _mediator = mediator; }

        private readonly IMediator _mediator;

        [HttpPost]
        [Route("api/employees")]
        public async Task<EmployeeResponse> Post([FromBody] CreateEmployeeRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        [Route("api/employees/{id:int}/dependents")]
        public async Task<IActionResult> Post([FromRoute] int id, [FromBody] CreateDependentRequest request)
        {
            request.EmployeeId = id;
            var response = await _mediator.Send(request);

            if (response == null) return NotFound("No such employee.");

            return Ok(response);
        }
    }
}
