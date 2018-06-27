using System.Threading;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Paylocity.API.Shared;
using Xunit;

namespace Paylocity.API.Features.Employees
{
    public class EmployeesHandlerTests
    {
        public EmployeesHandlerTests()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg => cfg.AddProfiles(GetType().Assembly));
            var options = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseInMemoryDatabase("Employees")
                .Options;
            _context = new EmployeeDbContext(options);
        }

        private readonly EmployeeDbContext _context;

        private CreateEmployeeResponse CreateEmployeeResponse()
        {
            var handler = new CreateEmployeeHandler(_context);
            var request = new CreateEmployeeRequest
            {
                FirstName = "First",
                LastName = "Last"
            };
            return handler.Handle(request, default(CancellationToken)).Result;
        }

        [Fact]
        public void create_dependent_handler_should_return_new_create_dependent_response()
        {
            var handler = new CreateDependentHandler(_context);
            var employee = CreateEmployeeResponse();
            var request = new CreateDependentRequest
            {
                FirstName = "First",
                LastName = "Last",
                EmployeeId = employee.Id
            };
            var actual = handler.Handle(request, default(CancellationToken)).Result;

            var expected = new CreateDependentResponse
            {
                EmployeeId = employee.Id,
                FirstName = "First",
                LastName = "Last",
                PersonalBenefitsCost = "$500.00",
                EmployeeAnnualBenefitsCost = "$1,500.00",
                EmployeeBenefitsCostPerPaycheck = "$57.69"
            };

            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void create_dependent_handler_should_return_null_for_missing_employee()
        {
            var handler = new CreateDependentHandler(_context);
            var request = new CreateDependentRequest
            {
                FirstName = "First",
                LastName = "Last",
                EmployeeId = 999
            };
            var actual = handler.Handle(request, default(CancellationToken)).Result;

            actual.Should().BeNull();
        }

        [Fact]
        public void create_employee_handler_should_return_new_create_employee_response()
        {
            var actual = CreateEmployeeResponse();

            var expected = new CreateEmployeeResponse
            {
                Id = actual.Id, // not possible to predict this value
                FirstName = "First",
                LastName = "Last",
                PersonalBenefitsCost = "$1,000.00",
                AnnualBenefitsCost = "$1,000.00",
                BenefitsCostPerPaycheck = "$38.46"
            };

            actual.Should().BeEquivalentTo(expected);
        }
    }
}