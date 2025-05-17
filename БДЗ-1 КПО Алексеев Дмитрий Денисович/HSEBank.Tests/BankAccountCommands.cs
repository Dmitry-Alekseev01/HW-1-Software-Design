using HSEBank.Accounting;
using HSEBank.BankAccounts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Tests;

public class BankAccountCommands
{
    private const string TestName = "Test Account";
    private const int TestBalance = 1000;
    private const int testID = 1;


    [Fact]
    public void AddCommandApplyTest()
    {
        BankAccountRepository _repoMock = new BankAccountRepository();
        BankAccountIDService _idServiceMock = new BankAccountIDService(_repoMock);
        BankAccountFactory _factoryMock = new BankAccountFactory();
        var command = new AddBankAccountCommand(_repoMock, _idServiceMock, _factoryMock, TestName, TestBalance);
        command.Apply();

        var bankAccounts = _repoMock.GetAll().ToList();

        Assert.Single(bankAccounts);
    }

    [Fact]
    public void AddCommandApply2Test()
    {
        BankAccountRepository _repoMock = new BankAccountRepository();
        BankAccountIDService _idServiceMock = new BankAccountIDService(_repoMock);
        BankAccountFactory _factoryMock = new BankAccountFactory();

        var command = new AddBankAccountCommand(_repoMock, _idServiceMock, _factoryMock, TestName, TestBalance);
        command.Apply();
        var command1 = new AddBankAccountCommand(_repoMock, _idServiceMock, _factoryMock, TestName, TestBalance);
        command1.Apply();


        var bankAccounts = _repoMock.GetAll().ToList();

        Assert.Equal(2, bankAccounts.Count);
    }

    [Fact]
    public void RemoveCommandApplyTest()
    {
        BankAccountRepository _repoMock = new BankAccountRepository();
        BankAccountIDService _idServiceMock = new BankAccountIDService(_repoMock);
        BankAccountFactory _factoryMock = new BankAccountFactory();

        var command = new AddBankAccountCommand(_repoMock, _idServiceMock, _factoryMock, TestName, TestBalance);
        command.Apply();
        var command1 = new DeleteBankAccountCommand(_repoMock, testID);
        command1.Apply();


        var bankAccounts = _repoMock.GetAll().ToList();

        Assert.Empty(bankAccounts);
    }
}
