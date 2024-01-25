namespace TestingWorkshop.MSTest;

[TestClass]
public class CalculatorMSTests
{
    [TestMethod]
    public void AddNumbers_InputTwoInt_GetCorrectAddition()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        int result = calculator.AddNumbers(10, 20);

        // Assert
        Assert.AreEqual(30, result);
    }

    [TestMethod]
    public void SubstractNumbers_InputTwoInt_GetCorrectSubstraction()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        int result = calculator.SubstractNumbers(50, 10);

        // Assert
        Assert.AreEqual(40, result);
    }

    [TestMethod]
    public void MultiplyNumbers_InputTwoInt_GetCorrectMultiplication()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        int result = calculator.MultiplyNumbers(2, 3);

        // Assert
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void DivideNumbers_InputTwoInt_GetCorrectDivision()
    {
        // Arrange
        Calculator calculator = new Calculator();

        // Act
        int result = calculator.DivideNumbers(50, 10);

        // Assert
        Assert.AreEqual(5, result);
    }
}
