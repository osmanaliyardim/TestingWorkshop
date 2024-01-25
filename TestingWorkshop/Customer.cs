namespace TestingWorkshop;

public class Customer
{
    public string GreetMessage { get; private set; }

    public string CombineNames(string firstName, string lastName)
    {
        return $"{firstName} {lastName}";
    }

    public string GreetWithName(string firstName, string lastName)
    {
        GreetMessage = $"Hello, Welcome {CombineNames(firstName, lastName)}!";

        return GreetMessage;
    }
}
