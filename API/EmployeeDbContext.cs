using Microsoft.EntityFrameworkCore;
using Paylocity.Benefits.Service.Entities;

namespace Paylocity.Benefits.Service
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