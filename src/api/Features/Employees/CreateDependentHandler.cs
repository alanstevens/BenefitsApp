using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BenefitsApp.API.Shared;
using BenefitsApp.API.Shared.Entities;
using MediatR;

namespace BenefitsApp.API.Features.Employees
{
    public class CreateDependentHandler : IRequestHandler<CreateDependentRequest, CreateDependentResponse>
    {
        public CreateDependentHandler(ApiDbContext context) { _context = context; }

        private readonly ApiDbContext _context;

        public Task<CreateDependentResponse> Handle(CreateDependentRequest request, CancellationToken cancellationToken)
        {
            var dependent = Mapper.Map<Dependent>(request);

            var employee = _context.Employees.SingleOrDefault(e => e.Id == dependent.EmployeeId);

            if (employee == null) return Task.FromResult<CreateDependentResponse>(null);

            if (employee.Dependents == null) employee.Dependents = new List<Dependent>();

            employee.Dependents.Add(dependent);

            var calculator = new BenefitsCalculator.BenefitsCalculator();

            calculator.CalculateBenefitsCostsFor(employee);

            _context.SaveChanges();

            return CreateResponse(dependent, employee);
        }

        private Task<CreateDependentResponse> CreateResponse(Dependent dependent, Employee employee)
        {
            var dependentResponse = Mapper.Map<DependentResponse>(dependent);
            var employeeResponse = Mapper.Map<EmployeeResponse>(employee);

            var response = new CreateDependentResponse
            {
                Employee = employeeResponse,
                Dependent = dependentResponse
            };

            return Task.FromResult(response);
        }
    }
}
