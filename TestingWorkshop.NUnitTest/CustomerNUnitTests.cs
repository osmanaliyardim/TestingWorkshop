namespace TestingWorkshop.NUnitTest;

[TestFixture]
public class CustomerNUnitTests
{
    private Customer customer;

    [SetUp]
    public void Setup()
    {
        // Arrange
        customer = new Customer();
    }

    [Test]
    public void GreetWithName_InputFirstAndLastName_ReturnGreetingWithFullName()
    {
        // Arrange part moved to constructor via Setup() method
        //Customer customer = new Customer();

        // Act
        customer.GreetWithName("Osman Ali", "Yardim");

        // Assert
        Assert.AreEqual(customer.GreetMessage, "Hello, Welcome Osman Ali Yardim!");
        Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Welcome Osman Ali Yardim!"));
        Assert.That(customer.GreetMessage, Does.Contain("Welcome"));
        Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
        Assert.That(customer.GreetMessage, Does.EndWith("!"));
        Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));

        // Case sensitive
        Assert.That(customer.GreetMessage, Does.Contain("Welcome").IgnoreCase);

        // Advanced concept to test multiple conditions, even if one of them fail it will continue to test
        //Assert.Multiple(() =>
        //{
        //    Assert.AreEqual(customer.GreetMessage, "Hello, Welcome Osman Ali Yardim!");
        //    Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Welcome Osman Ali Yardim!"));
        //    Assert.That(customer.GreetMessage, Does.Contain("1Welcome"));
        //    Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
        //    Assert.That(customer.GreetMessage, Does.EndWith("1!"));
        //    Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        //});
    }

    [Test]
    public void GreetMessage_NotGreeted_ReturnsNull()
    {
        // Arrange part moved to constructor via Setup() method
        //Customer customer = new Customer();

        // Act - no act, we want a null return
        //customer.GreetWithName("Osman Ali", "Yardim");

        // Assert
        Assert.IsNull(customer.GreetMessage);
    }

    [Test]
    public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
    {
        // Arrange part moved to constructor via Setup() method
        //Customer customer = new Customer();

        // Act
        customer.GreetWithName("Osman Ali", "Yardim");
        int discountResult = customer.Discount;

        // Assert
        //Assert.That(discountResult, Is.InRange(10, 19)); // will fail, 20 is out of range
        Assert.That(discountResult, Is.InRange(10, 25));
    }

    [Test]
    public void GreetWithName_InputEmptyFirstName_ThrowsArgumentNullException()
    {
        var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetWithName(" ", "Yardim"));

        Assert.AreEqual("Empty FirstName!", exceptionDetails.Message);

        Assert.That(() => customer.GreetWithName(" ", "Yardim"), 
            Throws.ArgumentException.With.Message.EqualTo("Empty FirstName!"));

        Assert.Throws<ArgumentException>(() => customer.GreetWithName("", "Yardim"));

        Assert.That(() => customer.GreetWithName(" ", "Yardim"),
            Throws.ArgumentException);
    }

    [Test]
    public void GreetWithName_InputEmptyLastName_ReturnsNotNull()
    {
        // Arrange part moved to constructor via Setup() method
        //Customer customer = new Customer();

        // Act
        var actualResult = customer.GreetWithName("Osman", "");

        // Assert
        Assert.IsNotNull(customer.GreetMessage);
        Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
    }

    [Test]
    public void CustomerType_CreateCustomerWithLessThan100Orders_ReturnsBasicCustomer()
    {
        // Arrange
        customer.OrderTotal = 99;

        // Act
        var actualResult = customer.GetCustomerDetails();

        // Assert
        Assert.That(actualResult, Is.TypeOf<BasicCustomer>());
    }

    [Test]
    public void CustomerType_CreateCustomerWithMoreThan100Orders_ReturnsPlatinumCustomer()
    {
        // Arrange
        customer.OrderTotal = 101;

        // Act
        var actualResult = customer.GetCustomerDetails();

        // Assert
        Assert.That(actualResult, Is.TypeOf<PlatinumCustomer>());
    }
}
