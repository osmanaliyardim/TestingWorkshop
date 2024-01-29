using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;

namespace TestingWorkshop.XUnitTest;

public class CustomerXUnitTests
{
    private Customer customer;
    
    public CustomerXUnitTests()
    {
        // Arrange
        customer = new Customer();
    }

    [Fact]
    public void GreetWithName_InputFirstAndLastName_ReturnGreetingWithFullName()
    {
        // Arrange part moved to constructor
        //Customer customer = new Customer();

        // Act
        customer.GreetWithName("Osman Ali", "Yardim");

        // Assert
        Assert.Equal("Hello, Welcome Osman Ali Yardim!", customer.GreetMessage);
        Assert.Equal("Hello, Welcome Osman Ali Yardim!", customer.GreetMessage);
        Assert.Contains("Welcome", customer.GreetMessage);
        Assert.StartsWith("Hello", customer.GreetMessage);
        Assert.EndsWith("!", customer.GreetMessage);
        Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);

        // Advanced concept to test multiple conditions, even if one of them fail it will continue to test
        //Assert.Multiple(() =>
        //{
        //    Assert.Equal("Hello, Welcome Osman Ali Yardim!", customer.GreetMessage);
        //    Assert.Equal("Hello, Welcome Osman Ali Yardim!", customer.GreetMessage);
        //    Assert.Contains("Welcome", customer.GreetMessage);
        //    Assert.StartsWith("Hello", customer.GreetMessage);
        //    Assert.EndsWith("!", customer.GreetMessage);
        //    Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);
        //});
    }

    [Fact]
    public void GreetMessage_NotGreeted_ReturnsNull()
    {
        // Arrange part moved to constructor via Setup() method
        //Customer customer = new Customer();

        // Act - no act, we want a null return
        //customer.GreetWithName("Osman Ali", "Yardim");

        // Assert
        Assert.Null(customer.GreetMessage);
    }

    [Fact]
    public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
    {
        // Arrange part moved to constructor via Setup() method
        //Customer customer = new Customer();

        // Act
        customer.GreetWithName("Osman Ali", "Yardim");
        int discountResult = customer.Discount;

        // Assert
        //Assert.InRange(discountResult, 10, 19); // will fail, 20 is out of range
        Assert.InRange(discountResult, 10, 25);
    }

    [Fact]
    public void GreetWithName_InputEmptyFirstName_ThrowsArgumentNullException()
    {
        var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetWithName(" ", "Yardim"));

        Assert.Equal("Empty FirstName!", exceptionDetails.Message);

        Assert.Throws<ArgumentException>(() => customer.GreetWithName(" ", "Yardim"));

        Assert.Throws<ArgumentException>(() => customer.GreetWithName("", "Yardim"));
    }

    [Fact]
    public void GreetWithName_InputEmptyLastName_ReturnsNotNull()
    {
        // Arrange part moved to constructor via Setup() method
        //Customer customer = new Customer();

        // Act
        var actualResult = customer.GreetWithName("Osman", "");

        // Assert
        Assert.NotNull(customer.GreetMessage);
        Assert.False(string.IsNullOrEmpty(customer.GreetMessage));
    }

    [Fact]
    public void CustomerType_CreateCustomerWithLessThan100Orders_ReturnsBasicCustomer()
    {
        // Arrange
        customer.OrderTotal = 99;

        // Act
        var actualResult = customer.GetCustomerDetails();

        // Assert
        Assert.IsType<BasicCustomer>(actualResult);
    }

    [Fact]
    public void CustomerType_CreateCustomerWithMoreThan100Orders_ReturnsPlatinumCustomer()
    {
        // Arrange
        customer.OrderTotal = 101;

        // Act
        var actualResult = customer.GetCustomerDetails();

        // Assert
        Assert.IsType<PlatinumCustomer>(actualResult);
    }
}
