using Moq;

namespace TestingWorkshop.NUnitTest;

[TestFixture]
public class ProductNUnitTests
{
    [Test]
    public void GetPrice_PlatinumCustomer_ReturnPriceWith20PercentDiscount()
    {
        // Arrange
        Product product = new Product() { Price = 100 };

        // Act
        var actualResult = product.GetPrice(new Customer() { IsPlatinum = true });
        //var actualResult = product.GetPrice(new Customer() { IsPlatinum = false });

        // Assert
        Assert.That(actualResult, Is.EqualTo(80)); // To test platinum customers
        //Assert.That(actualResult, Is.EqualTo(100)); // To test standard customers
    }

    [Test]
    // Mocking abuse example!!
    public void GetPriceMoqAbuse_PlatinumCustomer_ReturnPriceWith20PercentDiscount()
    {
        // Arrange
        Product product = new Product() { Price = 100 };
        var customer = new Mock<ICustomer>();
        customer.Setup(c => c.IsPlatinum).Returns(true);

        // Act
        var actualResult = product.GetPrice(customer.Object);
        //var actualResult = product.GetPrice(new Customer() { IsPlatinum = false });

        // Assert
        Assert.That(actualResult, Is.EqualTo(80)); // To test platinum customers
        //Assert.That(actualResult, Is.EqualTo(100)); // To test standard customers
    }
}
