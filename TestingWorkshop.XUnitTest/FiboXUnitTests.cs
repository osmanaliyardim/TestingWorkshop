namespace TestingWorkshop.XUnitTest;

public class FiboXUnitTests
{
    private Fibo fibo;

    public FiboXUnitTests()
    {
        // Arrange
        fibo = new Fibo();
    }

    [Fact]
    public void GetFiboSeries_InputRange1_ReturnsCorrectFiboSeries()
    {
        // Arrange
        fibo.Range = 1;
        var expectedResult = new List<int>() { 0 };

        // Act
        var actualResult = fibo.GetFiboSeries();

        // Assert
        Assert.NotEmpty(actualResult);
        Assert.Equal(actualResult.OrderBy(x => x), actualResult);
        Assert.Equal(expectedResult, actualResult);
    }

    [Fact]
    public void GetFiboSeries_InputRange6_ReturnsCorrectFiboSeries()
    {
        // Arrange
        fibo.Range = 6;
        var expectedResult = new List<int>() { 0, 1, 1, 2, 3, 5 };

        // Act
        var actualResult = fibo.GetFiboSeries();

        // Assert
        Assert.Contains(3, actualResult);
        Assert.Equal(6, actualResult.Count);
        Assert.DoesNotContain(4, actualResult);
        Assert.Equal(expectedResult, actualResult);
    }

    // Combined version with range parameter (just for experiment)
    [Theory]
    [InlineData(1)]
    [InlineData(6)]
    public void GetFiboSeries_InputRange_ReturnsCorrectFiboSeries(int range)
    {
        // Arrange
        fibo.Range = range;
        var expectedResultForRange6 = new List<int>() { 0, 1, 1, 2, 3, 5 };
        var expectedResultForRange1 = new List<int>() { 0 };

        // Act
        var actualResult = fibo.GetFiboSeries();

        // Assert
        Assert.NotEmpty(actualResult);
        Assert.Equal(actualResult.OrderBy(x => x), actualResult);
        Assert.DoesNotContain(4, actualResult);
    }
}
