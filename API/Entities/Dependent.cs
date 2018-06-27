using System.ComponentModel.DataAnnotations;

namespace Paylocity.Benefits.Service.Entities
{
    public class Dependent : Person
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}