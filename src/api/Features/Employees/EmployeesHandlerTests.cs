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
            _options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase("Employees")
                .Options;
        }

        private readonly DbContextOptions<ApiDbContext> _options;

        private EmployeeResponse CreateEmployeeResponse(ApiDbContext context)
        {
            var handler = new CreateEmployeeHandler(context);
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
            using (var context = new ApiDbContext(_options))
            {
                var handler = new CreateDependentHandler(context);
                var employee = CreateEmployeeResponse(context);
                var request = new CreateDependentRequest
                {
                    FirstName = "First",
                    LastName = "Last",
                    EmployeeId = employee.Id
                };
                var actual = handler.Handle(request, default(CancellationToken)).Result;

                var expected = new CreateDependentResponse
                {
                    Employee = new EmployeeResponse
                    {
                        Id = employee.Id,
                        FirstName = "First",
                        LastName = "Last",
                        PersonalBenefitsCost = "$1,000.00",
                        AnnualBenefitsCost = "$1,500.00",
                        BenefitsCostPerPaycheck = "$57.69"
                    },
                    Dependent = new DependentResponse
                    {
                        EmployeeId = employee.Id,
                        FirstName = "First",
                        LastName = "Last",
                        PersonalBenefitsCost = "$500.00"
                    }
                };
                actual.Should().BeEquivalentTo(expected);
            }
        }

        [Fact]
        public void create_dependent_handler_should_return_null_for_missing_employee()
        {
            using (var context = new ApiDbContext(_options))
            {
                var handler = new CreateDependentHandler(context);
                var request = new CreateDependentRequest
                {
                    FirstName = "First",
                    LastName = "Last",
                    EmployeeId = 999
                };
                var actual = handler.Handle(request, default(CancellationToken)).Result;

                actual.Should().BeNull();
            }
        }

        [Fact]
        public void create_employee_handler_should_return_new_create_employee_response()
        {
            using (var context = new ApiDbContext(_options))
            {
                var actual = CreateEmployeeResponse(context);

                var expected = new EmployeeResponse
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
}
