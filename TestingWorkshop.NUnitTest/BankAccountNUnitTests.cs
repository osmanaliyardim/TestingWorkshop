using Moq;

namespace TestingWorkshop.NUnitTest;

[TestFixture]
public class BankAccountNUnitTests
{
    //private BankAccount bankAccount;

    // Arrange
    [SetUp]
    public void Setup()
    {
        //var logMock = new Mock<ILogBook>();
        //logMock.Setup(l => l.LogMessage(""));
        //logMock.Setup(l => l.LogMessage("Deposit invoked.."));
        //bankAccount = new(logMock.Object);
    }

    //[Test]
    //public void DepositFake_Add100Dollars_ReturnTrue()
    //{
    //    // Arrange
    //    BankAccount bankAccount = new(new LogFake());

    //    // Act
    //    var actualResult = bankAccount.Deposit(100);

    //    // Assert
    //    Assert.IsTrue(actualResult);
    //    Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
    //}

    [Test]
    public void DepositMoq_Add100Dollars_ReturnsTrue()
    {
        // Arrange
        var logMock = new Mock<ILogBook>();
        //logMock.Setup(l => l.LogMessage(""));
        //logMock.Setup(l => l.LogMessage("Deposit invoked.."));
        BankAccount bankAccount = new(logMock.Object);

        // Act
        var actualResult = bankAccount.Deposit(100);

        // Assert
        Assert.IsTrue(actualResult);
        Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
    }

    [Test]
    public void Withdraw_Withdraw100DollarsWith200Balance_ReturnsTrue()
    {
        // Arrange
        var logMock = new Mock<ILogBook>();
        logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
        logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsAny<int>())).Returns(true);
        BankAccount bankAccount = new(logMock.Object);
        bankAccount.Deposit(200);

        // Act
        var actualResult = bankAccount.Withdraw(100);

        // Assert
        Assert.IsTrue(actualResult);
    }

    // Parameterized version
    [Test]
    [TestCase(200, 100)]
    [TestCase(200, 150)]
    public void Withdraw_TwoIntegers_ReturnsTrue(int depositAmount, int withdrawalAmount)
    {
        // Arrange
        var logMock = new Mock<ILogBook>();
        logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true); // Conditional return
        logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true); // Conditional return
        BankAccount bankAccount = new(logMock.Object);
        bankAccount.Deposit(depositAmount);

        // Act
        var actualResult = bankAccount.Withdraw(withdrawalAmount);

        // Assert
        Assert.IsTrue(actualResult);
    }

    [Test]
    [TestCase(200, 300)]
    public void Withdraw_Withdraw300DollarsWith200Balance_ReturnsFalse(int depositAmount, int withdrawalAmount)
    {
        // Arrange
        var logMock = new Mock<ILogBook>();
        logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
        logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x < 0))).Returns(false);
        logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false); // Default return value
        BankAccount bankAccount = new(logMock.Object);
        bankAccount.Deposit(depositAmount);

        // Act
        var actualResult = bankAccount.Withdraw(withdrawalAmount);

        // Assert
        Assert.IsFalse(actualResult);
    }

    [Test]
    public void MessageWithReturnString_LogMockString_ReturnsTrue()
    {
        // Arrange
        var logMock = new Mock<ILogBook>();
        string expectedResult = "hello";
        logMock.Setup(u => u.MessageWithReturnString(It.IsAny<string>())).Returns((string str) => str.ToLower());

        // Act
        var actualResult = logMock.Object.MessageWithReturnString("HELlo");

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void LogWithOutputResult_LogMockStringOutputStr_ReturnsTrue()
    {
        // Arrange
        var logMock = new Mock<ILogBook>();
        string expectedResult="outputstring";
        logMock.Setup(u => u.LogWithOutputResult(It.IsAny<string>(), out expectedResult)).Returns(true); // With out parameters

        // Act
        string actualOutput = "";
        var actualResult = logMock.Object.LogWithOutputResult("osman", out actualOutput);

        // Assert
        Assert.IsTrue(actualResult);
        Assert.That(actualOutput, Is.EqualTo(expectedResult));
    }

    [Test]
    public void LogWithRefObj_LogRefChecker_ReturnsTrue()
    {
        // Arrange
        var logMock = new Mock<ILogBook>();
        Customer customer = new Customer();
        Customer customerNotUsed = new Customer();
        logMock.Setup(u => u.LogWithRefObj(ref customer)).Returns(true); // With ref parameters

        // Act
        var actualResult = logMock.Object.LogWithRefObj(ref customer);
        //var actualResult = logMock.Object.LogWithRefObj(ref customerNotUsed); // This will fail because we set it up for ref customer

        // Assert
        Assert.IsTrue(actualResult);
    }

    [Test]
    public void PropertyCheck_SetAndGetLogTypeAndSeverityMock_MockTest()
    {
        // Arrange
        var logMock = new Mock<ILogBook>();
        logMock.SetupAllProperties(); // even if you change value of a property, it will arrange for new ones
        logMock.Setup(u => u.LogSeverity).Returns(10);
        logMock.Setup(u => u.LogType).Returns("warning");

        logMock.Object.LogSeverity = 100; // it will still pass the test because we used SetupAllProperties()

        // Act
        var actualSeverity = logMock.Object.LogSeverity;
        var actualLogType = logMock.Object.LogType;

        // Assert
        Assert.That(actualSeverity, Is.EqualTo(10));
        //Assert.That(actualSeverity, Is.EqualTo(100));
        Assert.That(actualLogType, Is.EqualTo("warning"));
    }

    [Test]
    public void CallbackLogToDb_MockInputs_MockTest()
    {
        // Arrange
        var logMock = new Mock<ILogBook>();
        
        string salute = "Hello, ";
        logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true)
            .Callback((string name) => salute += name); // with callback we can reach the passed string and manipulate it

        //int counter = 5;
        //logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true)
        //    .Callback(() => counter++); // the same with an integer

        // Act
        logMock.Object.LogToDb("Osman");
        //logMock.Object.LogToDb("Osman"); 5 + 1 + 1 = 7 (for integer test)

        // Assert
        Assert.That(salute, Is.EqualTo("Hello, Osman"));
    }

    [Test]
    public void BankLogDummy_VerificationExample()
    {
        // Arrange
        var logMock = new Mock<ILogBook>();
        BankAccount bankAccount = new BankAccount(logMock.Object);
        var expectedResult = 100;

        // Act
        bankAccount.Deposit(100);
        var actualResult = bankAccount.GetBalance();

        // Assert
        //Assert.AreEqual(actualResult, expectedResult);
        Assert.That(actualResult, Is.EqualTo(expectedResult));

        // Verification

        // To be sure if LogMessage() method executed exactly 4 times
        // 2 for Deposit method and 2 for GetBalance
        logMock.Verify(u => u.LogMessage(It.IsAny<string>()), Times.Exactly(4));

        // To be sure if LogSeverity property used exactly once and with the value of 101
        logMock.VerifySet(u => u.LogSeverity = 101, Times.Once);
        logMock.VerifyGet(u => u.LogSeverity, Times.Once);

        logMock.Verify(u => u.LogMessage("Deposit invoked.."), Times.AtLeastOnce);
        logMock.Verify(u => u.LogMessage($"Deposit successful! Current balance is {actualResult}$"), Times.AtLeastOnce);
        logMock.Verify(u => u.LogMessage("GetBalance invoked.."), Times.AtLeastOnce);
        logMock.Verify(u => u.LogMessage($"Your current balance is {actualResult}$"), Times.AtLeastOnce);
    }
}
