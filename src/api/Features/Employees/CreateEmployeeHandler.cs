using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BenefitsApp.API.Shared;
using BenefitsApp.API.Shared.Entities;
using MediatR;

namespace BenefitsApp.API.Features.Employees
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeRequest, EmployeeResponse>
    {
        public CreateEmployeeHandler(ApiDbContext context) { _context = context; }

        private readonly ApiDbContext _context;

        public Task<EmployeeResponse> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = Mapper.Map<Employee>(request);

            var calculator = new BenefitsCalculator.BenefitsCalculator();

            calculator.CalculateBenefitsCostsFor(employee);

            _context.Employees.Add(employee);

            _context.SaveChanges();

            var response = Mapper.Map<EmployeeResponse>(employee);

            return Task.FromResult(response);
        }
    }
}
