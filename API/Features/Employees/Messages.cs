using System.Collections.Generic;
using MediatR;

namespace Paylocity.Benefits.Service.Features.Employees
{
    public class CreateEmployeeRequest : IRequest<CreateEmployeeResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CreateEmployeeResponse
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

    public class CreateDependentResponse
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalBenefitsCost { get; set; }
        public string EmployeeAnnualBenefitsCost { get; set; }
        public string EmployeeBenefitsCostPerPaycheck { get; set; }
    }
}