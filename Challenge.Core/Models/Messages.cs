using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Core
{
    public static class Messages
    {
        public const string MustBeGreaterThanZero = "Your transaction amount must be greater than $0.00";
        public const string WithdrawalLimitError = "You have exceeded the withdrawal limit of ${0:0.00} for account {1}";
        public const string InsufficientFunds = "You have exceeded the funds available in account {1}: ${0:0.00}";
        public const string SuccessfulWithdrawal = "You have successfully wihdrawn ${0:0.00} from account {1}.  Your remaining balance is ${2:0.00}";
        public const string SuccessfulDeposit = "You have successfully deposited ${0:0.00} into account {1}.  Your new balance is ${2:0.00}";
        public const string SuccessfulTransfer = "You have successfully transferred ${0:0.00} from account {1} into account {2}.  Your new balance in account {1} is ${3:0.00}.  Your new balance in account {2} is  ${4:0.00}";
    }
}
