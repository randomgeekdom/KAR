namespace Challenge.Core.Models
{
    public class IndividualInvestmentAccount : InvestmentAccount
    {
        public override double WithdrawalLimit => 500;
    }
}