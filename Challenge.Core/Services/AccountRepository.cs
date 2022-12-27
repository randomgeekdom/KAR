using Challenge.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Core.Services
{
    public class AccountRepository : IAccountRepository
    {
        public Account? GetAccount(Bank bank, int id)
        {
            return bank.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Account> GetAccounts(Bank bank)
        {
            return bank.Accounts;
        }
    }
}
