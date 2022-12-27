namespace Challenge.Core.Models
{
    public abstract class InvestmentAccount : Account
    {
        public override double WithdrawalLimit => double.MaxValue;
    }
}