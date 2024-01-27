namespace TestingWorkshop.NUnitTest;

public class GradingCalculatorNUnitTests
{
    private GradingCalculator gradingCalculator;

    [SetUp]
    public void Setup()
    {
        // Arrange
        gradingCalculator = new GradingCalculator();
    }

    [Test]
    // Assert
    [TestCase(95, 90, ExpectedResult = "A")]
    [TestCase(85, 90, ExpectedResult = "B")]
    [TestCase(65, 90, ExpectedResult = "C")]
    [TestCase(95, 65, ExpectedResult = "B")]
    [TestCase(51, 55, ExpectedResult = "D")]
    [TestCase(95, 45, ExpectedResult = "F")]
    [TestCase(65, 45, ExpectedResult = "F")]
    [TestCase(50, 90, ExpectedResult = "F")]
    public string GetGrade_InputScoreAndAttendance_GetCorrectGrade(int score, int attendancePercentage)
    {
        // Arrange
        gradingCalculator.Score = score;
        gradingCalculator.AttendancePercentage = attendancePercentage;

        // Act
        return gradingCalculator.GetGrade();
    }
}
