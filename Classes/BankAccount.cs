namespace Classes;

public class BankAccount
{   
    private static int accountNumberSeed = 1000000000;
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance { get; }

    public BankAccount(string name, decimal initialBalance) 
    {
        this.Owner = name;
        this.Balance = initialBalance;
        Number = (accountNumberSeed).ToString();
        accountNumberSeed++;
    }

    public void MakeDeposit(decimal amount, DateTime date, string note)
    {
    }

    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
    }
}