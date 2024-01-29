namespace TestingWorkshop.XUnitTest;

public class GradingCalculatorXUnitTests
{
    private GradingCalculator gradingCalculator;

    public GradingCalculatorXUnitTests()
    {
        // Arrange
        gradingCalculator = new GradingCalculator();
    }

    [Theory]
    // Assert
    [InlineData(95, 90, "A")]
    [InlineData(85, 90, "B")]
    [InlineData(65, 90, "C")]
    [InlineData(95, 65, "B")]
    [InlineData(51, 55, "D")]
    [InlineData(95, 45, "F")]
    [InlineData(65, 45, "F")]
    [InlineData(50, 90, "F")]
    public void GetGrade_InputScoreAndAttendance_GetCorrectGrade(int score, int attendancePercentage, string expectedResult)
    {
        // Arrange
        gradingCalculator.Score = score;
        gradingCalculator.AttendancePercentage = attendancePercentage;

        // Act
        var actualResult = gradingCalculator.GetGrade();

        // Assert
        Assert.Equal(expectedResult, actualResult); 
    }
}
