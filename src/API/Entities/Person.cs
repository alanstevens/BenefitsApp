using System.ComponentModel.DataAnnotations;

namespace Paylocity.Benefits.Service.Entities
{
    public abstract class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal PersonalBenefitsCost { get; set; }
    }
}