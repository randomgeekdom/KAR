namespace Challenge.Core.Models
{
    public class CorporateInvestmentAccount : InvestmentAccount
    {
        public override double WithdrawalLimit => 500;
    }
}