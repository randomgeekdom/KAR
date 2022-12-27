using System.Security.Principal;

namespace Challenge.Core.Services
{
    public class AccountService : IAccountService
    {
        public TransactionResult Deposit(Account account, double amount)
        {
            if (amount <= 0)
            {
                return GetGreaterThanZeroError();
            }

            account.Balance += amount;

            return new TransactionResult
            {
                DispenseAmount = 0,
                IsSuccessful = true,
                Message = string.Format(Messages.SuccessfulDeposit, amount, account.Number, account.Balance)
            };
        }

        public TransactionResult Transfer(Account accountFrom, Account accountTo, double amount, Guid customerId)
        {
            if (accountFrom.OwnerId != customerId)
            {
                return GetCustomerNotAccountOwner(accountFrom, customerId);
            }

            if (amount <= 0)
            {
                return GetGreaterThanZeroError();
            }

            if (amount > accountFrom.Balance)
            {
                return GetBalanceError(Messages.InsufficientFunds, accountFrom.Balance, accountFrom.Number);
            }

            accountFrom.Balance -= amount;
            accountTo.Balance += amount;

            return new TransactionResult
            {
                DispenseAmount = 0,
                IsSuccessful = true,
                Message = string.Format(Messages.SuccessfulTransfer, amount, accountFrom.Number, accountTo.Number, accountFrom.Balance, accountTo.Balance)
            };
        }

        public TransactionResult Withdraw(Account account, double amount, Guid customerId)
        {
            if (account.OwnerId != customerId)
            {
                return GetCustomerNotAccountOwner(account, customerId);
            }

            if (amount <= 0)
            {
                return GetGreaterThanZeroError();
            }

            if (amount > account.WithdrawalLimit)
            {
                return GetBalanceError(Messages.WithdrawalLimitError, account.WithdrawalLimit, account.Number);
            }

            if (amount > account.Balance)
            {
                return GetBalanceError(Messages.InsufficientFunds, account.Balance, account.Number);
            }

            account.Balance -= amount;

            return new TransactionResult
            {
                DispenseAmount = amount,
                IsSuccessful = true,
                Message = string.Format(Messages.SuccessfulWithdrawal, amount, account.Number, account.Balance)
            };
        }

        private TransactionResult GetBalanceError(string message, double limitAmount, string accountNumber)
        {
            return new TransactionResult
            {
                DispenseAmount = 0,
                IsSuccessful = false,
                Message = string.Format(message, limitAmount.ToString(), accountNumber)
            };
        }

        private TransactionResult GetCustomerNotAccountOwner(Account account, Guid customerId)
        {
            return new TransactionResult
            {
                DispenseAmount = 0,
                IsSuccessful = false,
                Message = string.Format(Messages.CustomerNotAccountOwner, account.Number)
            };
        }

        private TransactionResult GetGreaterThanZeroError()
        {
            return new TransactionResult
            {
                DispenseAmount = 0,
                IsSuccessful = false,
                Message = Messages.MustBeGreaterThanZero
            };
        }
    }
}