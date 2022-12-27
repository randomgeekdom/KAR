namespace Challenge.Core
{
    public class CheckingAccount : Account
    {
        public override double WithdrawalLimit => 500;
    }
}