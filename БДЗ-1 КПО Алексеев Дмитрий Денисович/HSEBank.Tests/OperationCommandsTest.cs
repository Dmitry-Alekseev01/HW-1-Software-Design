using HSEBank.Accounting;
using HSEBank.BankAccounts;
using HSEBank.Categories;
using HSEBank.Operations;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Tests;

public class OperationCommandsTest
{
    static OperationRepository _repoMock = new OperationRepository();
    static OperationIDService _idServiceMock = new OperationIDService(_repoMock);
    static OperationFactory _factoryMock = new OperationFactory();
    private const bool type = true;
    private const string TestCategoryName = "Test Category";
    private Category category = new Category(testBankAccountID, new CategoryParams(type, TestCategoryName));
    private const int testCategoryID = 1;

    private const int amountTest = 100;
    private const bool typeOperation = true;
    private const string desc = "Agil";

    private const int testBankAccountID = 1;
    private const string TestBankAccountName = "Test Account";
    private const int TestBalance = 1000;
    private BankAccount bankAccount = new BankAccount(testBankAccountID, new BankAccountParams(TestBankAccountName, TestBalance));

    private int testID = 1;

    [Fact]
    public void AddCommandApplyTest()
    {
        OperationRepository _repoMock = new OperationRepository();
        OperationIDService _idServiceMock = new OperationIDService(_repoMock);//command = CreateAddCommand();
        OperationFactory _factoryMock = new OperationFactory();
        
        var command = new AddOperationCommand(_repoMock, _idServiceMock, _factoryMock, type, bankAccount, amountTest, category, desc);
        command.Apply();

        var operations = _repoMock.GetAll().ToList();

        Assert.Single(operations);
    }

    [Fact]
    public void AddCommandApply2Test()
    {
        OperationRepository _repoMock = new OperationRepository();
        OperationIDService _idServiceMock = new OperationIDService(_repoMock);//command = CreateAddCommand();
        OperationFactory _factoryMock = new OperationFactory();

        var command = new AddOperationCommand(_repoMock, _idServiceMock, _factoryMock, type, bankAccount, amountTest, category, desc);
        command.Apply();
        var command1 = new AddOperationCommand(_repoMock, _idServiceMock, _factoryMock, type, bankAccount, amountTest, category, desc);
        command1.Apply();


        var operations = _repoMock.GetAll().ToList();

        Assert.Equal(2, operations.Count);
    }

    [Fact]
    public void RemoveCommandApplyTest()
    {
        OperationRepository _repoMock = new OperationRepository();
        OperationIDService _idServiceMock = new OperationIDService(_repoMock);//command = CreateAddCommand();
        OperationFactory _factoryMock = new OperationFactory();

        var command = new AddOperationCommand(_repoMock, _idServiceMock, _factoryMock, type, bankAccount, amountTest, category, desc);
        command.Apply();
        var command1 = new DeleteOperationCommand(_repoMock, testID);
        command1.Apply();


        var operations = _repoMock.GetAll().ToList();

        Assert.Empty(operations);
    }

}
