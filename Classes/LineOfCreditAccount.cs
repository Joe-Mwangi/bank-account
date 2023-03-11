namespace Classes;

public class LineOfCreditAccount : BankAccount
{
    public LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : base(name, initialBalance, -creditLimit)
    {
    }
    public override void PerformEndMonthTransactions() 
    {
        if (Balance < 0) {
            // Negate the balance to get a positive interest charge:
            decimal interest = -Balance * 0.07m;
            MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
        }
    }
    //add overdraft fee
    protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) =>
        isOverdrawn ? new Transaction(-2000, DateTime.Now, "Apply overdraft fee") : default;
}