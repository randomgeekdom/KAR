using Challenge.Core.Models;

namespace Challenge.Core.Services
{
    public interface IAccountRepository
    {
        Account? GetAccount(Bank bank, int id);
        IEnumerable<Account> GetAccounts(Bank bank);
    }
}