using System.Collections.Generic;
using System.Linq;
using BenefitsApp.API.Shared;
using BenefitsApp.API.Shared.Entities;

namespace BenefitsApp.API.Features.Employees.BenefitsCalculator
{
    public class BenefitsCalculator
    {
        // NOTE: I'm uncomfortable mutating these values by reference but,
        // since this is an entity attached to a context, there isn't another good option- HAS 06/25/2018 
        public void CalculateBenefitsCostsFor(Employee employee)
        {
            CalculateBenefitCostForEachDependent(employee.Dependents);

            var totalCostForAllDependents = CalculateAnnualTotalForAllDependents(employee.Dependents);

            employee.PersonalBenefitsCost = CalculateEmployeeBenefitsCost(employee);

            employee.AnnualBenefitsCost = employee.PersonalBenefitsCost + totalCostForAllDependents;

            employee.BenefitsCostPerPaycheck = CalculateBenefitsCostPerPaycheck(employee.AnnualBenefitsCost);
        }

        public void CalculateBenefitCostForEachDependent(IEnumerable<Dependent> dependents) =>
            dependents?.ToList().ForEach(d => d.PersonalBenefitsCost = CalculateDependentBenefitsCost(d));

        public decimal CalculateAnnualTotalForAllDependents(IEnumerable<Dependent> dependents)
        {
            if (dependents == null || !dependents.Any()) return 0;
            return dependents.Select(d => d.PersonalBenefitsCost).Sum();
        }

        public decimal CalculateEmployeeBenefitsCost(Employee employee)
        {
            var discount = CalculatePersonDiscount(employee);
            return 1000m * discount;
        }

        public decimal CalculateDependentBenefitsCost(Dependent dependent)
        {
            var discount = CalculatePersonDiscount(dependent);
            return 500m * discount;
        }

        public decimal CalculatePersonDiscount(Person person)
        {
            if (person.FirstName.IsBlank()) return 1m;
            return person.FirstName.StartsWith("A") ? 0.9m : 1m;
        }

        public decimal CalculateBenefitsCostPerPaycheck(decimal annualBenefitsCost) => annualBenefitsCost / 26m;
    }
}
