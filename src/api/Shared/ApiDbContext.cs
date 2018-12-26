using BenefitsApp.API.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BenefitsApp.API.Shared
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
    }
}
