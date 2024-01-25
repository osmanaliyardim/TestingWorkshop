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
}
