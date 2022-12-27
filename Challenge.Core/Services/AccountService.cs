using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Core.Services
{
    public class AccountService : IAccountService
    {
        public TransactionResult Withdraw(Account account, double amount)
        {
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

        public TransactionResult Transfer(Account accountFrom, Account accountTo, double amount)
        {
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

        private TransactionResult GetBalanceError(string message, double limitAmount, string accountNumber)
        {
            return new TransactionResult
            {
                DispenseAmount = 0,
                IsSuccessful = false,
                Message = string.Format(message, limitAmount.ToString(), accountNumber)
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
