using EmployeeManagement.Repository.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.EmployeeManagement.Persistence.EFCore.EntityConfiguration
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        const string TableName = "Phone";
        const string Schema = "dbo";
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable(TableName, Schema);
            builder.HasKey(p => p.PhoneId);
            builder.HasOne(p => p.Employee).WithMany(e => e.Phones);
            builder.Property(p => p.PhoneNumber).HasMaxLength(11);
            builder.Property(p => p.PhoneType).HasMaxLength(10).HasConversion(
                p => p.ToString(),
                p => (PhoneTypeEnums)Enum.Parse(typeof(PhoneTypeEnums), p)); ;
        }
    }
}
