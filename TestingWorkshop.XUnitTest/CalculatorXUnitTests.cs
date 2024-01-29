namespace TestingWorkshop.XUnitTest;

public class CalculatorXUnitTests
{
    [Fact]
    public void AddNumbers_InputTwoInt_GetCorrectAddition()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        int result = calculator.AddNumbers(10, 20);

        // Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void SubstractNumbers_InputTwoInt_GetCorrectSubstraction()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        int result = calculator.SubstractNumbers(50, 10);

        // Assert
        Assert.Equal(40, result);
    }

    [Fact]
    public void MultiplyNumbers_InputTwoInt_GetCorrectMultiplication()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        int result = calculator.MultiplyNumbers(2, 3);

        // Assert
        Assert.Equal(6, result);
    }

    [Fact]
    public void DivideNumbers_InputTwoInt_GetCorrectDivision()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        int result = calculator.DivideNumbers(50, 10);

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void IsNumberOdd_InputOddInt_ReturnsTrue()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        bool oddResult = calculator.IsNumberOdd(1);

        // Assert
        Assert.True(oddResult);
    }

    [Fact]
    public void IsNumberOdd_InputEvenInt_ReturnFalse()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        bool evenResult = calculator.IsNumberOdd(2);

        // Assert
        Assert.False(evenResult);
    }

    [Fact]
    public void IsNumberEven_InputOddInt_ReturnFalse()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        bool oddResult = calculator.IsNumberEven(1);

        // Assert
        Assert.False(oddResult);
    }

    [Fact]
    public void IsNumberEven_InputEvenInt_ReturnTrue()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        bool evenResult = calculator.IsNumberEven(2);

        // Assert
        Assert.True(evenResult);
        //Assert.That(evenResult, Is.True);
        //Assert.That(evenResult, Is.EqualTo(true));
    }

    [Theory]
    [InlineData(11)]
    [InlineData(13)]
    public void IsNumberOdd_InputOddInts_ReturnsTrue(int num)
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        bool oddResult = calculator.IsNumberOdd(num);

        // Assert
        Assert.True(oddResult);
    }

    [Theory]
    [InlineData(10, false)]
    [InlineData(11, true)]
    public void IsNumberOdd_InputInt_ReturnTrueIfOdd(int num, bool expectedResult)
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        var actualResult = calculator.IsNumberOdd(num);

        // Assert
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData(5.4, 10.5)] // 15.9
    [InlineData(5.43, 10.53)] // 15.959999..
    [InlineData(5.49, 10.59)] // 16.08
    public void AddDoubleNumbers_InputTwoDouble_GetCorrectAddition(double num1, double num2)
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        double doubleResult = calculator.AddDoubleNumbers(num1, num2);

        // Act + Assert
        Assert.Equal(15.9, doubleResult, .2);  // Delta value is 0.2 so it accepts results between 15.7-16.1
    }

    [Fact]
    public void GetOddRange_InputMinAndMaxRange_ReturnsValidOddNumberRange()
    {
        // Arrange
        Calculator calculator = new Calculator();
        List<int> expectedOddRange = new() { 5, 7, 9 }; // Odd numbers between 5-10

        // Act
        var actualResult = calculator.GetOddRange(5, 10);

        // Assert
        Assert.Equal(expectedOddRange, actualResult);
        Assert.Contains(7, actualResult);
        Assert.NotEmpty(actualResult);
        Assert.Equal(3, actualResult.Count);
        Assert.DoesNotContain(8, actualResult);
        Assert.Equal(actualResult.OrderBy(x => x), actualResult);
    }
}
