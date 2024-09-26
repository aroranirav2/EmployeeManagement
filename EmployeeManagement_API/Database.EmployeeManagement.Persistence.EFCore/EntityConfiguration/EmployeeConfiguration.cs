using EmployeeManagement.Repository.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.EmployeeManagement.Persistence.EFCore.EntityConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        const string TableName = "Employee";
        const string Schema = "dbo";
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(TableName, Schema);
            builder.HasKey(e => e.EmployeeId);
            builder.HasOne(d => d.Department).WithMany(e => e.Employees);
            builder.Property(e => e.Gender).HasConversion(
                e => e.ToString(),
                e => (GenderEnums)Enum.Parse(typeof(GenderEnums), e));
        }
    }
}
