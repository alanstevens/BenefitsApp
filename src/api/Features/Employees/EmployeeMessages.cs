using MediatR;

namespace Paylocity.API.Features.Employees
{
    public class CreateEmployeeRequest : IRequest<EmployeeResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalBenefitsCost { get; set; }
        public string AnnualBenefitsCost { get; set; }
        public string BenefitsCostPerPaycheck { get; set; }
    }

    public class CreateDependentRequest : IRequest<CreateDependentResponse>
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class DependentResponse
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalBenefitsCost { get; set; }
    }

    public class CreateDependentResponse
    {
        public EmployeeResponse Employee { get; set; }
        public DependentResponse Dependent { get; set; }
    }
}
