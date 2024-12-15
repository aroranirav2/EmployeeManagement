using EmployeeManagement.Repository.Domain;

namespace EmployeeManagement.Repository.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAllAccounts();
        Task<Account?> GetAccountByIdAsync(Guid accountId); 
    }
}
