﻿namespace TestingWorkshop;

public class Customer
{
    public int Discount = 15;

    public int OrderTotal { get; set; }

    public string GreetMessage { get; private set; }

    public string CombineNames(string firstName, string lastName)
    {
        return $"{firstName} {lastName}";
    }

    public string GreetWithName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("Empty FirstName!");
        }
        
        GreetMessage = $"Hello, Welcome {CombineNames(firstName, lastName)}!";
        Discount = 20;

        return GreetMessage;
    }

    public CustomerType GetCustomerDetails()
    {
        if (OrderTotal < 100)
        {
            return new BasicCustomer();
        }

        return new PlatinumCustomer();
    }
}

public class CustomerType
{

}

public class BasicCustomer : CustomerType
{

}

public class PlatinumCustomer : CustomerType
{

}
