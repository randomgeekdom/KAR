namespace Challenge.Core
{
    public abstract class InvestmentAccount : Account
    {
        public override double WithdrawalLimit => double.MaxValue;
    }
}