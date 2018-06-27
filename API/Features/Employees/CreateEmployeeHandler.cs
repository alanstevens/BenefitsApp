using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Paylocity.Benefits.Service.Entities;
using Paylocity.Benefits.Service.Shared;

namespace Paylocity.Benefits.Service.Features.Employees
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeRequest, CreateEmployeeResponse>
    {
        public CreateEmployeeHandler(EmployeeDbContext context) { _context = context; }

        private readonly EmployeeDbContext _context;

        public Task<CreateEmployeeResponse> Handle(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            var employee = Mapper.Map<Employee>(request);

            var calculator = new BenefitsCalculator();

            calculator.CalculateBenefitsCostsFor(employee);

            _context.Employees.Add(employee);

            _context.SaveChanges();

            var response = Mapper.Map<CreateEmployeeResponse>(employee);

            return Task.FromResult(response);
        }
    }
}