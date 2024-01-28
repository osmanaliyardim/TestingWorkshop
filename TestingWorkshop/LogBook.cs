namespace TestingWorkshop;

public interface ILogBook
{
    public int LogSeverity { get; set; }

    public string LogType { get; set; }

    void LogMessage(string message);

    bool LogToDb(string message);

    bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal);

    string MessageWithReturnString(string message);

    bool LogWithOutputResult(string str, out string outputStr);

    bool LogWithRefObj(ref Customer customer);
}

public class LogBook : ILogBook
{
    public int LogSeverity { get; set; }
    public string LogType { get; set; }

    public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
    {
        if (balanceAfterWithdrawal >= 0)
        {
            Console.WriteLine("Withrawal successful!");

            return true;
        }

        Console.WriteLine("Withrawal failed!");

        return false;
    }

    public void LogMessage(string message)
    {
        Console.WriteLine(message);
    }

    public bool LogToDb(string message)
    {
        Console.Write(message);

        return true;
    }

    public bool LogWithOutputResult(string str, out string outputStr)
    {
        outputStr = "Hello " + str;

        return true;
    }

    public bool LogWithRefObj(ref Customer customer)
    {
        return true;
    }

    public string MessageWithReturnString(string message)
    {
        Console.WriteLine(message.ToLower());

        return message.ToLower();
    }
}

//public class LogFake : ILogBook
//{
//    public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
//    {
//        throw new NotImplementedException();
//    }

//    public void LogMessage(string message)
//    {
//    }

//    public bool LogToDb(string message)
//    {
//        throw new NotImplementedException();
//    }
//}