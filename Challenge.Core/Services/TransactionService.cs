namespace Challenge.Core.Services
{
    public class TransactionService
    {
        private readonly IAccountRepository accountRepository;

        public TransactionService(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
    }
}
