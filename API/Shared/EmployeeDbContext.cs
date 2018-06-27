using Microsoft.EntityFrameworkCore;
using Paylocity.API.Shared.Entities;

namespace Paylocity.API.Shared
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
            : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
    }
}