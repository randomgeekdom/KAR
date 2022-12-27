namespace Challenge.Core.Services
{
    public interface IAccountService
    {
        TransactionResult Deposit(Account account, double amount);
        TransactionResult Transfer(Account accountFrom, Account accountTo, double amount, Guid customerId);
        TransactionResult Withdraw(Account account, double amount, Guid customerId);
    }
}