using Bongo.Models.ModelValidations;

namespace Bongo.Models.Tests
{
    [TestFixture]
    public class DateInFutureAttributeTests
    {
        private DateInFutureAttribute dateInFutureAttribute;

        // Arrange
        [SetUp]
        public void SetUp()
        {
            dateInFutureAttribute = new DateInFutureAttribute();
        }

        [TestCase(100, ExpectedResult = true)]
        [TestCase(-100, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = false)]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(-1, ExpectedResult = false)]
        public bool DateValidator_InputExpectedDateRange_DateValidity(int additionalTimeInSecs)
        {
            // Arrange moved to SetUp() method
            //DateInFutureAttribute dateInFuture = new DateInFutureAttribute(() => DateTime.Now);

            // Act
            return dateInFutureAttribute.IsValid(DateTime.Now.AddSeconds(additionalTimeInSecs));

            // TestCase is created with NUnit so that we dont need Act and Assert part
            // Act
            //var actualResult = dateInFutureAttribute.IsValid(DateTime.Now.AddSeconds(seconds));

            // Assert
            //Assert.AreEqual(true, actualResult);
        }

        [Test]
        public void DateValidator_NotValidDateOrAnyDate_ReturnsErrorMessage()
        {
            // Act
            var actualResult = dateInFutureAttribute;

            // Assert
            Assert.That(actualResult.ErrorMessage, Is.EqualTo("Date must be in the future"));
        }
    }
}