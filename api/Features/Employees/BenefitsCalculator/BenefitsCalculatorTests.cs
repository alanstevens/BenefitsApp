using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using Paylocity.API.Shared.Entities;
using Xunit;

namespace Paylocity.API.Features.Employees.BenefitsCalculator
{
    public class BenefitsCalculatorTests
    {
        public BenefitsCalculatorTests() { _calculator = new BenefitsCalculator(); }

        private readonly BenefitsCalculator _calculator;

        [Theory]
        [InlineData("Alan")]
        [InlineData("Alice")]
        [InlineData("Antoine")]
        [InlineData("Annie")]
        public void should_return_discount_for_names_starting_with_a(string firstName)
        {
            var person = Substitute.For<Person>();
            person.FirstName = firstName;
            var actual = _calculator.CalculatePersonDiscount(person);
            actual.Should().Be(0.9m);
        }

        [Theory]
        [InlineData("James")]
        [InlineData("Carole")]
        [InlineData("Mark")]
        [InlineData("Janice")]
        public void should_not_return_discount_for_names_not_starting_with_a(string firstName)
        {
            var person = Substitute.For<Person>();
            person.FirstName = firstName;
            var actual = _calculator.CalculatePersonDiscount(person);
            actual.Should().Be(1m);
        }

        [Theory]
        [InlineData("Alan")]
        [InlineData("Alice")]
        [InlineData("Antoine")]
        [InlineData("Annie")]
        public void should_calculate_dependent_benefits_cost_for_name_starting_with_a(string firstName)
        {
            var dependent = new Dependent {FirstName = firstName};
            var actual = _calculator.CalculateDependentBenefitsCost(dependent);
            var expected = 500m * 0.9m;
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("James")]
        [InlineData("Carole")]
        [InlineData("Mark")]
        [InlineData("Janice")]
        public void should_calculate_dependent_benefits_cost_for_name_not_starting_with_a(string firstName)
        {
            var dependent = new Dependent {FirstName = firstName};
            var actual = _calculator.CalculateDependentBenefitsCost(dependent);
            var expected = 500m;
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("Alan")]
        [InlineData("Alice")]
        [InlineData("Antoine")]
        [InlineData("Annie")]
        public void should_calculate_employee_benefits_cost_for_name_starting_with_a(string firstName)
        {
            var employee = new Employee {FirstName = firstName};
            var actual = _calculator.CalculateEmployeeBenefitsCost(employee);
            var expected = 1000m * 0.9m;
            actual.Should().Be(expected);
        }

        [Theory]
        [InlineData("James")]
        [InlineData("Carole")]
        [InlineData("Mark")]
        [InlineData("Janice")]
        public void should_calculate_employee_benefits_cost_for_name_not_starting_with_a(string firstName)
        {
            var employee = new Employee {FirstName = firstName};
            var actual = _calculator.CalculateEmployeeBenefitsCost(employee);
            var expected = 1000m;
            actual.Should().Be(expected);
        }

        [Fact]
        public void
            calculate_annual_total_costs_for_all_dependents_should_be_zero_for_empty_or_null_list_of_dependents()
        {
            var actual = _calculator.CalculateAnnualTotalForAllDependents(new List<Dependent>());

            actual.Should().Be(0);

            actual = _calculator.CalculateAnnualTotalForAllDependents(null);

            actual.Should().Be(0);
        }

        [Fact]
        public void calculate_dependent_costs_should_not_thow_exception_for_null_list()
        {
            var ex = Record.Exception(() => _calculator.CalculateBenefitCostForEachDependent(null));

            ex.Should().BeNull();
        }

        [Fact]
        public void should_calculate_annual_total_for_all_dependents()
        {
            var dependents = new List<Dependent>
            {
                new Dependent {FirstName = "Bob", PersonalBenefitsCost = 500}, // 500
                new Dependent {FirstName = "Carole", PersonalBenefitsCost = 500}, // 500
                new Dependent {FirstName = "Ted", PersonalBenefitsCost = 500}, // 500
                new Dependent {FirstName = "Alice", PersonalBenefitsCost = 450} // 450
            };
            var actual = _calculator.CalculateAnnualTotalForAllDependents(dependents);
            actual.Should().Be(1950m);
        }

        [Fact]
        public void should_calculate_benefits_cost_for_employee()
        {
            var employee = new Employee
            {
                FirstName = "Sam",
                Dependents = new List<Dependent>
                {
                    new Dependent {FirstName = "Bob"}, // 500
                    new Dependent {FirstName = "Carole"}, // 500
                    new Dependent {FirstName = "Ted"}, // 500
                    new Dependent {FirstName = "Alice"} // 450
                }
            };
            _calculator.CalculateBenefitsCostsFor(employee);

            // Ugh, mutation by reference. - HAS 06/25/2018 
            employee.AnnualBenefitsCost.Should().Be(2950m);
            employee.BenefitsCostPerPaycheck.Should().Be(2950m / 26m);
        }

        [Fact]
        public void should_calculate_benefits_cost_per_paycheck()
        {
            var annualCost = 3000m;
            var actual = _calculator.CalculateBenefitsCostPerPaycheck(annualCost);
            var expected = annualCost / 26m;
            actual.Should().Be(expected);
        }

        [Fact]
        public void should_calculate_dependent_costs()
        {
            var dependents = new List<Dependent>
            {
                new Dependent {FirstName = "Bob"}, // 500
                new Dependent {FirstName = "Carole"}, // 500
                new Dependent {FirstName = "Ted"}, // 500
                new Dependent {FirstName = "Alice"} // 450
            };
            _calculator.CalculateBenefitCostForEachDependent(dependents);
            dependents.Single(d => d.FirstName == "Bob").PersonalBenefitsCost.Should().Be(500);
            dependents.Single(d => d.FirstName == "Carole").PersonalBenefitsCost.Should().Be(500);
            dependents.Single(d => d.FirstName == "Ted").PersonalBenefitsCost.Should().Be(500);
            dependents.Single(d => d.FirstName == "Alice").PersonalBenefitsCost.Should().Be(450);
        }
    }
}
