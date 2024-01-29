using Moq;

namespace TestingWorkshop.XUnitTest;

public class ProductXUnitTests
{
    [Fact]
    public void GetPrice_PlatinumCustomer_ReturnPriceWith20PercentDiscount()
    {
        // Arrange
        Product product = new Product() { Price = 100 };

        // Act
        var actualResult = product.GetPrice(new Customer() { IsPlatinum = true });
        //var actualResult = product.GetPrice(new Customer() { IsPlatinum = false });

        // Assert
        Assert.Equal(80, actualResult); // To test platinum customers
        //Assert.Equal(100, actualResult); // To test standard customers
    }

    [Fact]
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
        Assert.Equal(80, actualResult); // To test platinum customers
        //Assert.Equal(100, actualResult); // To test standard customers
    }
}
