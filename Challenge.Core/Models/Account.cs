namespace Challenge.Core.Models
{
    public abstract class Account
    {
        public double Balance { get; set; }
        public abstract double WithdrawalLimit { get; }
    }
}