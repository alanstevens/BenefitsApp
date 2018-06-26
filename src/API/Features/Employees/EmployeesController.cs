using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace Paylocity.Benefits.Service.Features.Employees
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
