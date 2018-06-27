namespace Paylocity.API.Shared.Entities
{
    public class Dependent : Person
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}