using Challenge.Core.Services;

namespace Challenge.Core.Tests
{
    public class AccountServiceTests
    {
        private Guid realCustomerId = Guid.Parse("d172f53e-24be-408a-ad21-ba654cde9553");
        private readonly AccountService sut = new AccountService();

        #region WithdrawTests
        [Fact]
        public void WhenWithdrawingAndAmountIsNotGreaterThanZero_ThenUnsuccessful()
        {
            var account = this.GetCheckingAccount(500);
            Assert.False(sut.Withdraw(account, -4, realCustomerId).IsSuccessful);
        }

        [Fact]
        public void WhenWithdrawingAndAmountIsGreaterThanBalance_ThenUnsuccessful()
        {
            var account = this.GetCheckingAccount(400);
            Assert.False(sut.Withdraw(account, 401, realCustomerId).IsSuccessful);
        }

        [Fact]
        public void WhenWithdrawingAndAmountIsGreaterThanWithdrawalLimit_ThenUnsuccessful()
        {
            var account = this.GetCheckingAccount(50000);
            Assert.False(sut.Withdraw(account, 501, realCustomerId).IsSuccessful);
        }

        [Fact]
        public void WhenWithdrawingAndCurrentCustomerIsNotOwner_ThenUnsuccessful()
        {
            var account = this.GetCheckingAccount(500);
            Assert.False(sut.Withdraw(account, 50, Guid.Empty).IsSuccessful);
        }

        [Fact]
        public void WhenWithdrawingThenWithdraw()
        {
            var account = this.GetCheckingAccount(50000);
            var result = sut.Withdraw(account, 400, realCustomerId);
            Assert.True(result.IsSuccessful);
            Assert.Equal(400, result.DispenseAmount);
            Assert.Equal(49600, account.Balance);
        }

        #endregion

        #region TransferTests


        [Fact]
        public void WhenTransferringAndAmountIsNotGreaterThanZero_ThenUnsuccessful()
        {
            var account = this.GetCheckingAccount(500);
            var account2 = this.GetInvestmentAccount(500);
            Assert.False(sut.Transfer(account, account2, -4, realCustomerId).IsSuccessful);
        }

        [Fact]
        public void WhenTransferringAndAmountIsGreaterThanBalance_ThenUnsuccessful()
        {
            var account = this.GetCheckingAccount(300);
            var account2 = this.GetInvestmentAccount(500);
            Assert.False(sut.Transfer(account, account2, 301, realCustomerId).IsSuccessful);
        }

        [Fact]
        public void WhenTransferringAndCurrentCustomerIsNotOwnerOfFromAccount_ThenUnsuccessful()
        {
            var account = this.GetCheckingAccount(500);
            var account2 = this.GetInvestmentAccount(500);
            Assert.False(sut.Transfer(account, account2, 50, Guid.Empty).IsSuccessful);
        }

        [Fact]
        public void WhenTransferringThenTransfer()
        {
            var account = this.GetCheckingAccount(500);
            var account2 = this.GetInvestmentAccount(500);
            var result = sut.Transfer(account, account2, 400, realCustomerId);
            Assert.True(result.IsSuccessful);
            Assert.Equal(100, account.Balance);
            Assert.Equal(900, account2.Balance);
        }
        #endregion


        #region Deposit Tests
        [Fact]
        public void WhenDepositingAndAmountIsNotGreaterThanZero_ThenUnsuccessful()
        {
            var account = this.GetCheckingAccount(500);
            Assert.False(sut.Deposit(account, -4).IsSuccessful);
        }

        [Fact]
        public void WhenDepositingThenDeposit()
        {
            var account = this.GetCheckingAccount(50000);
            var result = sut.Deposit(account, 400);
            Assert.True(result.IsSuccessful);
            Assert.Equal(50400, account.Balance);
        }

        #endregion

        private CheckingAccount GetCheckingAccount(double balance = 0)
        {
            return new CheckingAccount
            {
                Number = "1",
                Balance = balance,
                OwnerId = realCustomerId
            };
        }

        private InvestmentAccount GetInvestmentAccount(double balance = 0)
        {
            return new CorporateInvestmentAccount
            {
                Number = "2",
                Balance = balance,
                OwnerId = realCustomerId
            };
        }
    }
}