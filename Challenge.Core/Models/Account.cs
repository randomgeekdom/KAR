namespace Challenge.Core
{
    public abstract class Account
    {
        public string Number { get; set; } = string.Empty;
        public double Balance { get; set; }
        public abstract double WithdrawalLimit { get; }
    }
}