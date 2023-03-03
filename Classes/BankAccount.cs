namespace Classes;

public class BankAccount
{   
    private List<Transaction> allTransactions = new List<Transaction>();
    private static int accountNumberSeed = 1000000000;

    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance 
    {
        get {
            decimal balance = 0;
            foreach(var item in allTransactions) {
                balance += item.Amount;
            }
            return balance;
        }
    }

    public BankAccount(string name, decimal initialBalance) 
    {
        Owner = name;
        Number = (accountNumberSeed).ToString();
        accountNumberSeed++;

        MakeDeposit(initialBalance, DateTime.Now, "initial balance");
    }


    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
        if(amount <= 0) {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
        if(amount <= 0) {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
        }
        if(Balance  - amount < 0) {
            throw new InvalidOperationException("Not sufficient funds in your account");
        }
        var withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);
    }
}