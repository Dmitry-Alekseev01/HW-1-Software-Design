using HSEBank.Accounting;
using HSEBank.BankAccounts;
using Moq;
using NSubstitute;
using Xunit;

public class AddBankAccountCommandTests
{
    static BankAccountRepository _repoMock = new BankAccountRepository();
    static BankAccountIDService _idServiceMock = new BankAccountIDService(_repoMock);
    static BankAccountFactory _factoryMock = new BankAccountFactory();
    private const string TestName = "Test Account";
    private const int TestBalance = 1000;
    private const int GeneratedId = 123;
    private const int testID = 1;

    [Fact]
    public void ShouldGenerateAccountAndAddAddCommandToCommandService()
    {
        PendingCommandService PendingCommandService = new PendingCommandService();
        BankAccountRepository _repoMock = new BankAccountRepository();
        BankAccountIDService _idServiceMock = new BankAccountIDService(_repoMock);
        BankAccountFactory _factoryMock = new BankAccountFactory();

        var bankAccountService = new BankAccountInventoryService(PendingCommandService, _repoMock, _idServiceMock, _factoryMock);

        bankAccountService.AddBankAccountPending(TestName, TestBalance);

        Assert.Single(PendingCommandService.UnappliedCommands);
    }

    [Fact]
    public void Apply_ShouldGenerateAccountAndAddRemoveCommandToCommandService()
    {
        PendingCommandService PendingCommandService = new PendingCommandService();
        BankAccountRepository _repoMock = new BankAccountRepository();
        BankAccountIDService _idServiceMock = new BankAccountIDService(_repoMock);
        BankAccountFactory _factoryMock = new BankAccountFactory();

        var bankAccountService = new BankAccountInventoryService(PendingCommandService, _repoMock, _idServiceMock, _factoryMock);

        bankAccountService.AddBankAccountPending(TestName, TestBalance);

        PendingCommandService.SaveChanges();

        bankAccountService.RemoveBankAccountPending(testID);

        Assert.Single(PendingCommandService.UnappliedCommands);
    }

    [Fact]
    public void Apply_ShouldGenerateAccountAndAddGetCommandToCommandService()
    {
        PendingCommandService PendingCommandService = new PendingCommandService();
        BankAccountRepository _repoMock = new BankAccountRepository();
        BankAccountIDService _idServiceMock = new BankAccountIDService(_repoMock);
        BankAccountFactory _factoryMock = new BankAccountFactory();

        var command1 = new AddBankAccountCommand(_repoMock, _idServiceMock, _factoryMock, TestName, TestBalance);
        var bankAccountService = new BankAccountInventoryService(PendingCommandService, _repoMock, _idServiceMock, _factoryMock);

        bankAccountService.AddBankAccountPending(TestName, TestBalance);

        PendingCommandService.SaveChanges();

        bankAccountService.GetBankAccountPending(testID);

        Assert.Single(PendingCommandService.UnappliedCommands);
    }

    [Fact]
    public void Apply_ShouldGenerateAccountAndAddUpdateCommandToCommandService()
    {
        PendingCommandService PendingCommandService = new PendingCommandService();
        BankAccountRepository _repoMock = new BankAccountRepository();
        BankAccountIDService _idServiceMock = new BankAccountIDService(_repoMock);
        BankAccountFactory _factoryMock = new BankAccountFactory();

        var bankAccountService = new BankAccountInventoryService(PendingCommandService, _repoMock, _idServiceMock, _factoryMock);

        bankAccountService.AddBankAccountPending(TestName, TestBalance);

        PendingCommandService.SaveChanges();

        bankAccountService.UpdateBankAccountPending(testID);

        Assert.Single(PendingCommandService.UnappliedCommands);
    }


    [Fact]
    public void ToString_ShouldReturnFormattedString()
    {
        // Arrange
        var command = new AddBankAccountCommand(_repoMock, _idServiceMock, _factoryMock, TestName, TestBalance);

        // Act
        var result = command.ToString();

        // Assert
        Assert.Equal($"Bank account added. Name: {TestName}. Balance: {TestBalance}.", result);
    }
}