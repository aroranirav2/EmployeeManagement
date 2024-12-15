using APICommonServices.Dtos;
using EmployeeManagement.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Account.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<AccountDto>>> GetAllAccounts()
        {
            var accounts = _accountRepository.GetAllAccounts();
            var accountDtos = new List<AccountDto>();
            return accountDtos;
        }
    }
}
