using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Paylocity.Benefits.Service.Entities
{
    public class Employee: Person
    {
        public List<Dependent> Dependents;
        public decimal AnnualBenefitsCost { get; set; }
        public decimal BenefitsCostPerPaycheck { get; set; }
            
    }
}