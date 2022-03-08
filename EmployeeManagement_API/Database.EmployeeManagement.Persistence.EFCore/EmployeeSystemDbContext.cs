using Database.EmployeeManagement.Persistence.EFCore.EntityConfiguration;
using EmployeeManagement.Repository.Domain;
using Microsoft.EntityFrameworkCore;

namespace Database.EmployeeManagement.Persistence.EFCore
{
    public class EmployeeSystemDbContext : DbContext
    {
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        public EmployeeSystemDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneConfiguration());
        }
    }
}
