using Classes;

var account = new BankAccount("Joe", 1000);
var account2 = new BankAccount("Mwangi", 2000);
var account3 = new BankAccount("John", 500);
var account4 = new BankAccount("Kim", 3000);
var account5 = new BankAccount("Bob", 1500);

account5.MakeDeposit(700, DateTime.Now, "Mshwari saving");
Console.WriteLine($"Account: {account5.Number}\nOwner: {account5.Owner}\nBalance: {account5.Balance}\n");

account.MakeWithdrawal(900, DateTime.Now, "Sherehe");
Console.WriteLine($"Account: {account.Number}\nOwner: {account.Owner}\nBalance: {account.Balance}\n");

account5.MakeWithdrawal(2000, DateTime.Now, "Pay loan");
Console.WriteLine($"Account: {account5.Number}\nOwner: {account5.Owner}\nBalance: {account5.Balance}\n");

// Test for a negative balance.
try
{
    account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
}
catch (InvalidOperationException e)
{
    Console.WriteLine("Exception caught trying to overdraw");
    Console.WriteLine(e.ToString());
}

// Test that the initial balances must be positive.
BankAccount invalidAccount;
try
{
    invalidAccount = new BankAccount("invalid", -55);
}
catch (ArgumentOutOfRangeException e)
{
    Console.WriteLine("Exception caught creating account with negative balance");
    Console.WriteLine(e.ToString());
    return;
}