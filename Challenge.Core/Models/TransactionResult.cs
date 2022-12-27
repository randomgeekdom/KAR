namespace Challenge.Core
{
    public class TransactionResult
    {
        public double DispenseAmount { get; set; }
        public bool IsSuccessful { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}