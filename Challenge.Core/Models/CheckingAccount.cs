namespace Challenge.Core.Models
{
    public class CheckingAccount : Account
    {
        public override double WithdrawalLimit => 500;
    }
}