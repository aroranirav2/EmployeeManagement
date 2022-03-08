using EmployeeManagement.Repository.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.EmployeeManagement.Persistence.EFCore.EntityConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        const string TableName = "Address";
        const string Schema = "dbo";
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(TableName, Schema);
            builder.HasKey(a => a.AddressId);
            builder.Property(a => a.AddressId).ValueGeneratedOnAdd();
            builder.HasOne(a => a.Employee).WithMany(e => e.Addresses);
            builder.Property(a => a.City).HasMaxLength(50);
            builder.Property(a => a.State).HasMaxLength(50);
            builder.Property(a => a.ZipCode).HasMaxLength(6);
        }
    }
}
