using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Paylocity.API.Features.Employees
{
    [ApiController]
    public class ApiController : Controller
    {
        private readonly IMediator _mediator;

        public ApiController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        [Route("api/employees")]
        public async Task<CreateEmployeeResponse> Post([FromBody] CreateEmployeeRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        [Route("api/employees/{id}/dependents")]
        public async Task<IActionResult> Post([FromBody] CreateDependentRequest request)
        {
            var response = await _mediator.Send(request);

            if (response == null) return NotFound("No such employee.");

            return Ok(response);
        }
    }

}
