namespace TestingWorkshop;

public class BankAccount
{
    public int Balance { get; private set; }
    private readonly ILogBook _logBook;

    public BankAccount(ILogBook logBook)
    {
        Balance = 0;
        _logBook = logBook; 
    }

    public bool Deposit(int amount)
    {
        _logBook.LogSeverity = 101;
        var forTest = _logBook.LogSeverity;
        _logBook.LogMessage("Deposit invoked..");

        Balance += amount;

        _logBook.LogMessage($"Deposit successful! Current balance is {Balance}$");

        return true;
    }

    public bool Withdraw(int amount)
    {
        _logBook.LogMessage("Withdraw invoked..");

        if (amount <= Balance)
        {
            _logBook.LogToDb($"Withdraw successful! Current balance is {Balance}$");

            Balance -= amount;

            return _logBook.LogBalanceAfterWithdrawal(Balance);
        }

        return _logBook.LogBalanceAfterWithdrawal(Balance - amount); ;
    }

    public int GetBalance()
    {
        _logBook.LogMessage($"GetBalance invoked..");
        _logBook.LogMessage($"Your current balance is {Balance}$");

        return Balance;
    }
}
