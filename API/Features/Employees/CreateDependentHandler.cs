using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Paylocity.API.Shared;
using Paylocity.API.Shared.Entities;

namespace Paylocity.API.Features.Employees
{
    public class CreateDependentHandler : IRequestHandler<CreateDependentRequest, CreateDependentResponse>
    {
        public CreateDependentHandler(EmployeeDbContext context) { _context = context; }

        private readonly EmployeeDbContext _context;

        private Task<CreateDependentResponse> CreateResponse(Dependent dependent, Employee employee)
        {
            var response = Mapper.Map<CreateDependentResponse>(dependent);

            response.EmployeeAnnualBenefitsCost = employee.AnnualBenefitsCost.ToCurrency();

            response.EmployeeBenefitsCostPerPaycheck = employee.BenefitsCostPerPaycheck.ToCurrency();

            return Task.FromResult(response);
        }

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
    }
}