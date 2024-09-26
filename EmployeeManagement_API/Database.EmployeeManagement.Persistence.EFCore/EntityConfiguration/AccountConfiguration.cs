using EmployeeManagement.Repository.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.EmployeeManagement.Persistence.EFCore.EntityConfiguration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        const string TableName = "Account";
        const string Schema = "dbo";
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable(TableName, Schema);
            builder.HasKey(a => a.AccountId);
        }
    }
}
