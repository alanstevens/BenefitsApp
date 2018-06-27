using System.Collections.Generic;

namespace Paylocity.API.Shared.Entities
{
    public class Employee: Person
    {
        public List<Dependent> Dependents;
        public decimal AnnualBenefitsCost { get; set; }
        public decimal BenefitsCostPerPaycheck { get; set; }
            
    }
}