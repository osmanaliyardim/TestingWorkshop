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
}
