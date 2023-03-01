using EmployeeManagement.Repository.Domain;
using EmployeeManagement.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Database.EmployeeManagement.Persistence.EFCore.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EmployeeSystemDbContext _employeeSystemDbContext;

        public AccountRepository(EmployeeSystemDbContext employeeSystemDbContext)
        {
            _employeeSystemDbContext = employeeSystemDbContext;
        }
        public async Task<Account?> GetAccountByIdAsync(Guid accountId) =>
            await _employeeSystemDbContext.Account
                .Where(a => a.AccountId == accountId)
                .AsNoTracking()
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

        public IEnumerable<Account> GetAllAccounts() =>
            _employeeSystemDbContext.Account.AsNoTracking();

    }
}
