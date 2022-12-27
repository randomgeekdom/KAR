// See https://aka.ms/new-console-template for more information

using Challenge.Core;
using Challenge.Core.Services;
using Newtonsoft.Json;

Guid realCustomerId = Guid.Parse("d172f53e-24be-408a-ad21-ba654cde9553");

var checkingAccount = new CheckingAccount
{
    Balance = 600,
    Number = "11111",
    OwnerId = realCustomerId
};

var individualInvestmentAccount = new IndividualInvestmentAccount
{
    Balance = 600,
    Number = "22222",
    OwnerId = realCustomerId
};

var corporateInvestmentAccount = new CorporateInvestmentAccount
{
    Balance = 600,
    Number = "33333",
    OwnerId = realCustomerId
};

var bank = new Bank
{
    Name = "Hello Bank",
    Accounts = new List<Account>
    {
        checkingAccount,
        individualInvestmentAccount,
        corporateInvestmentAccount,
    }
};

var accountService = new AccountService();

Console.WriteLine("Please hit any key after each message to continue");

Console.WriteLine("Withdrawing from my checking account: 700, 600, 400, -4");
Console.WriteLine(JsonConvert.SerializeObject(accountService.Withdraw(checkingAccount, 700, realCustomerId)) + Environment.NewLine);
Console.WriteLine(JsonConvert.SerializeObject(accountService.Withdraw(checkingAccount, 600, realCustomerId)) + Environment.NewLine);
Console.WriteLine(JsonConvert.SerializeObject(accountService.Withdraw(checkingAccount, 400, realCustomerId)) + Environment.NewLine);
Console.WriteLine(JsonConvert.SerializeObject(accountService.Withdraw(checkingAccount, -4, realCustomerId)) + Environment.NewLine);
Console.ReadKey();



Console.WriteLine("Withdrawing from my individual investment account: 700, 600, 400, -4");
Console.WriteLine(JsonConvert.SerializeObject(accountService.Withdraw(individualInvestmentAccount, 700, realCustomerId)) + Environment.NewLine);
Console.WriteLine(JsonConvert.SerializeObject(accountService.Withdraw(individualInvestmentAccount, 600, realCustomerId)) + Environment.NewLine);
Console.WriteLine(JsonConvert.SerializeObject(accountService.Withdraw(individualInvestmentAccount, 400, realCustomerId)) + Environment.NewLine);
Console.WriteLine(JsonConvert.SerializeObject(accountService.Withdraw(individualInvestmentAccount, -4, realCustomerId)) + Environment.NewLine);
Console.ReadKey();


Console.WriteLine("Withdrawing from my corporate investment account: 700, 600, 400, -4");
Console.WriteLine(JsonConvert.SerializeObject(accountService.Withdraw(corporateInvestmentAccount, 700, realCustomerId)) + Environment.NewLine);
Console.WriteLine(JsonConvert.SerializeObject(accountService.Withdraw(corporateInvestmentAccount, 600, realCustomerId)) + Environment.NewLine);
Console.WriteLine(JsonConvert.SerializeObject(accountService.Withdraw(corporateInvestmentAccount, 400, realCustomerId)) + Environment.NewLine);
Console.WriteLine(JsonConvert.SerializeObject(accountService.Withdraw(corporateInvestmentAccount, -4, realCustomerId)) + Environment.NewLine);
Console.ReadKey();



Console.WriteLine("Depositing into my checking account: 700, -4");
Console.WriteLine(JsonConvert.SerializeObject(accountService.Deposit(checkingAccount, 700)) + Environment.NewLine);
Console.WriteLine(JsonConvert.SerializeObject(accountService.Deposit(checkingAccount, -4)) + Environment.NewLine);
Console.ReadKey();

Console.WriteLine("Depositing into my individual investment  account: 700, -4");
Console.WriteLine(JsonConvert.SerializeObject(accountService.Deposit(individualInvestmentAccount, 700)) + Environment.NewLine);
Console.WriteLine(JsonConvert.SerializeObject(accountService.Deposit(individualInvestmentAccount, -4)) + Environment.NewLine);
Console.ReadKey();


Console.WriteLine("Depositing into my corporate investment  account: 700, -4");
Console.WriteLine(JsonConvert.SerializeObject(accountService.Deposit(corporateInvestmentAccount, 700)) + Environment.NewLine);
Console.WriteLine(JsonConvert.SerializeObject(accountService.Deposit(corporateInvestmentAccount, -4)) + Environment.NewLine);
Console.ReadKey();


Console.WriteLine("Transferring from my corporate investment account into my personal account: 700, -4");
Console.WriteLine(JsonConvert.SerializeObject(accountService.Transfer(corporateInvestmentAccount, checkingAccount, 700, realCustomerId)) + Environment.NewLine);
Console.ReadKey();

Console.WriteLine("Withdrawing from my checking account $2 with bad owner ");
Console.WriteLine(JsonConvert.SerializeObject(accountService.Withdraw(checkingAccount, 2, Guid.Empty)) + Environment.NewLine);
Console.ReadKey();


Console.WriteLine("Transferring from my checking account into investment account $2 with bad owner ");
Console.WriteLine(JsonConvert.SerializeObject(accountService.Transfer(checkingAccount, individualInvestmentAccount, 2, Guid.Empty)) + Environment.NewLine);



Console.ReadKey();
Console.ReadKey();
Console.ReadKey();