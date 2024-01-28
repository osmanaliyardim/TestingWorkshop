namespace TestingWorkshop.NUnitTest;

[TestFixture]
public class FiboNUnitTests
{
    private Fibo fibo;

    [SetUp]
    public void Setup()
    {
        // Arrange
        fibo = new Fibo();
    }

    [Test]
    public void GetFiboSeries_InputRange1_ReturnsCorrectFiboSeries()
    {
        // Arrange
        fibo.Range = 1;
        var expectedResult = new List<int>() { 0 };

        // Act
        var actualResult = fibo.GetFiboSeries();

        // Assert
        Assert.IsNotEmpty(actualResult);
        Assert.That(actualResult, Is.Ordered.Ascending);
        Assert.That(actualResult, Is.EquivalentTo(expectedResult));
    }

    [Test]
    public void GetFiboSeries_InputRange6_ReturnsCorrectFiboSeries()
    {
        // Arrange
        fibo.Range = 6;
        var expectedResult = new List<int>() { 0, 1, 1, 2, 3, 5 };

        // Act
        var actualResult = fibo.GetFiboSeries();

        // Assert
        Assert.That(actualResult, Does.Contain(3));
        Assert.That(actualResult.Count, Is.EqualTo(6));
        Assert.That(actualResult, Does.Not.Contain(4));
        //Assert.That(actualResult, Has.No.Member(4)); // another way
        Assert.That(actualResult, Is.EquivalentTo(expectedResult));
    }

    // Combined version with range parameter (just for experiment)
    [Test]
    [TestCase(1)]
    [TestCase(6)]
    public void GetFiboSeries_InputRange_ReturnsCorrectFiboSeries(int range)
    {
        // Arrange
        fibo.Range = range;
        var expectedResultForRange6 = new List<int>() { 0, 1, 1, 2, 3, 5 };
        var expectedResultForRange1 = new List<int>() { 0 };

        // Act
        var actualResult = fibo.GetFiboSeries();

        // Assert
        Assert.IsNotEmpty(actualResult);
        Assert.That(actualResult, Is.Ordered.Ascending);
        //Assert.That(actualResult, Is.EquivalentTo(expectedResultForRange1)); // Not a common test case
        //Assert.That(actualResult, Does.Contain(3));   // Not a common test case
        //Assert.That(actualResult.Count, Is.EqualTo(6)); // Not a common test case
        Assert.That(actualResult, Does.Not.Contain(4));
        //Assert.That(actualResult, Has.No.Member(4)); // another way
        //Assert.That(actualResult, Is.EquivalentTo(expectedResultForRange6)); // Not a common test case
    }
}
