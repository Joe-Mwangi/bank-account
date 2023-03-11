using Classes;

var account = new BankAccount("Joe", 1000);
var account2 = new BankAccount("Mwangi", 2000);
var account3 = new BankAccount("John", 500);
var account4 = new BankAccount("Kim", 3000);
var account5 = new BankAccount("Bob", 1500);

account5.MakeDeposit(700, DateTime.Now, "Mshwari saving");
Console.WriteLine(account5.GetAccountHistory());

account.MakeWithdrawal(900, DateTime.Now, "Sherehe");
Console.WriteLine(account.GetAccountHistory());

account5.MakeWithdrawal(2000, DateTime.Now, "Pay loan");
Console.WriteLine(account5.GetAccountHistory());

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

var giftCard = new GiftCardAccount("gift card", 100, 50);
giftCard.MakeWithdrawal(20, DateTime.Now, "Get expensive coffee");
giftCard.MakeWithdrawal(50, DateTime.Now, "Buy groceries");
giftCard.PerformEndMonthTransactions();
// can make additional deposits:
giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
Console.WriteLine(giftCard.GetAccountHistory());

var savings = new InterestEarningAccount("savings account", 10000);
savings.MakeDeposit(750, DateTime.Now, "save some money");
savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
savings.PerformEndMonthTransactions();
Console.WriteLine(savings.GetAccountHistory());

var lineOfCredit = new LineOfCreditAccount("line of credit", 0, 2000);
// How much is too much to borrow?
lineOfCredit.MakeWithdrawal(10000m, DateTime.Now, "Take out monthly advance");
lineOfCredit.MakeDeposit(500m, DateTime.Now, "Pay back small amount");
lineOfCredit.MakeWithdrawal(50000m, DateTime.Now, "Emergency funds for repairs");
lineOfCredit.MakeDeposit(1500m, DateTime.Now, "Partial restoration on repairs");
lineOfCredit.PerformEndMonthTransactions();
Console.WriteLine(lineOfCredit.GetAccountHistory());