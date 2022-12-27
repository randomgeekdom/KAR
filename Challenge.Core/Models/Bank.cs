namespace Challenge.Core.Models
{
    public class Bank
    {
        public string Name { get; set; }
        public IEnumerable<Account> Accounts { get; set; } = new List<Account>();
    }
}