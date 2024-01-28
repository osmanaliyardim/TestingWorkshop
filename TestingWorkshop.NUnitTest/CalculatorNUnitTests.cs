namespace TestingWorkshop.NUnitTest;

[TestFixture]
public class CalculatorNUnitTests
{
    [Test]
    public void AddNumbers_InputTwoInt_GetCorrectAddition()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        int result = calculator.AddNumbers(10, 20);

        // Assert
        Assert.AreEqual(30, result);
    }

    [Test]
    public void SubstractNumbers_InputTwoInt_GetCorrectSubstraction()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        int result = calculator.SubstractNumbers(50, 10);

        // Assert
        Assert.AreEqual(40, result);
    }

    [Test]
    public void MultiplyNumbers_InputTwoInt_GetCorrectMultiplication()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        int result = calculator.MultiplyNumbers(2, 3);

        // Assert
        Assert.AreEqual(6, result);
    }

    [Test]
    public void DivideNumbers_InputTwoInt_GetCorrectDivision()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        int result = calculator.DivideNumbers(50, 10);

        // Assert
        Assert.AreEqual(5, result);
    }

    [Test]
    public void IsNumberOdd_InputOddInt_ReturnTrue()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        bool oddResult = calculator.IsNumberOdd(1);

        // Assert
        Assert.IsTrue(oddResult);
        //Assert.That(oddResult, Is.True);
        //Assert.That(oddResult, Is.EqualTo(true));
    }

    [Test]
    public void IsNumberOdd_InputEvenInt_ReturnFalse()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        bool evenResult = calculator.IsNumberOdd(2);

        // Assert
        Assert.IsFalse(evenResult);
        //Assert.That(evenResult, Is.False);
        //Assert.That(evenResult, Is.EqualTo(false));
    }

    [Test]
    public void IsNumberEven_InputOddInt_ReturnFalse()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        bool oddResult = calculator.IsNumberEven(1);

        // Assert
        Assert.IsFalse(oddResult);
        //Assert.That(oddResult, Is.False);
        //Assert.That(oddResult, Is.EqualTo(false));
    }

    [Test]
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

    [Test]
    [TestCase(11)]
    [TestCase(13)]
    public void IsNumberOdd_InputOddInt_ReturnTrue(int num)
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        bool oddResult = calculator.IsNumberOdd(num);

        // Assert
        Assert.IsTrue(oddResult);
        //Assert.That(oddResult, Is.True);
        //Assert.That(oddResult, Is.EqualTo(true));
    }

    [Test]
    [TestCase(10, ExpectedResult = false)]
    [TestCase(11, ExpectedResult = true)]
    public bool IsNumberOdd_InputInt_ReturnTrueIfOdd(int num)
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act + Assert
        return calculator.IsNumberOdd(num);
    }

    [Test]
    [TestCase(5.4, 10.5)] // 15.9
    [TestCase(5.43, 10.53)] // 15.959999..
    [TestCase(5.49, 10.59)] // 16.08
    public void AddDoubleNumbers_InputTwoDouble_GetCorrectAddition(double num1, double num2)
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        double doubleResult = calculator.AddDoubleNumbers(num1, num2);

        // Act + Assert
        Assert.AreEqual(15.9, doubleResult, .2);  // Delta value is 0.2 so it accepts results between 15.7-16.1
    }

    [Test]
    public void GetOddRange_InputMinAndMaxRange_ReturnsValidOddNumberRange()
    {
        // Arrange
        Calculator calculator = new Calculator();
        List<int> expectedOddRange = new() { 5, 7, 9 }; // Odd numbers between 5-10

        // Act
        var result = calculator.GetOddRange(5, 10);

        // Assert
        Assert.That(result, Is.EquivalentTo(expectedOddRange));
        //Assert.AreEqual(expectedOddRange, result);
        //Assert.Contains(7, result);
        Assert.That(result, Does.Contain(7));
        Assert.That(result, Is.Not.Empty);
        Assert.That(result.Count, Is.EqualTo(3));
        Assert.That(result, Has.No.Member(8));
        Assert.That(result, Is.Ordered.Ascending);
        Assert.That(result, Is.Unique);
    }
}
