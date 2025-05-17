using HSEBank.Accounting;
using HSEBank.BankAccounts;
using HSEBank.Categories;
using HSEBank.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Tests;

public class OperationServiceTest
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
    public void ShouldGenerateAccountAndAddAddCommandToCommandService()
    {
        PendingCommandService PendingCommandService = new PendingCommandService();
        OperationRepository _repoMock = new OperationRepository();
        OperationIDService _idServiceMock = new OperationIDService(_repoMock); 
        OperationFactory _factoryMock = new OperationFactory(); 
        
        var operationService = new OperationInventoryService(PendingCommandService, _repoMock, _idServiceMock, _factoryMock);

        operationService.AddOperationPending(type, bankAccount, amountTest, category, desc);

        Assert.Single(PendingCommandService.UnappliedCommands);
    }

    [Fact]
    public void Apply_ShouldGenerateAccountAndAddRemoveCommandToCommandService()
    {
        PendingCommandService PendingCommandService = new PendingCommandService();
        OperationRepository _repoMock = new OperationRepository();
        OperationIDService _idServiceMock = new OperationIDService(_repoMock); 
        OperationFactory _factoryMock = new OperationFactory(); 

        var categoryService = new OperationInventoryService(PendingCommandService, _repoMock, _idServiceMock, _factoryMock);

        categoryService.AddOperationPending(type, bankAccount, amountTest, category, desc);

        PendingCommandService.SaveChanges();

        categoryService.RemoveOperationPending(testID);

        Assert.Single(PendingCommandService.UnappliedCommands);
    }

    [Fact]
    public void Apply_ShouldGenerateAccountAndAddGetCommandToCommandService()
    {
        PendingCommandService PendingCommandService = new PendingCommandService();
        OperationRepository _repoMock = new OperationRepository();
        OperationIDService _idServiceMock = new OperationIDService(_repoMock); 
        OperationFactory _factoryMock = new OperationFactory(); 

        var categoryService = new OperationInventoryService(PendingCommandService, _repoMock, _idServiceMock, _factoryMock);

        categoryService.AddOperationPending(type, bankAccount, amountTest, category, desc);

        PendingCommandService.SaveChanges();

        categoryService.GetOperationPending(testID);

        Assert.Single(PendingCommandService.UnappliedCommands);
    }

    [Fact]
    public void Apply_ShouldGenerateAccountAndAddUpdateCommandToCommandService()
    {
        PendingCommandService PendingCommandService = new PendingCommandService();
        OperationRepository _repoMock = new OperationRepository();
        OperationIDService _idServiceMock = new OperationIDService(_repoMock); 
        OperationFactory _factoryMock = new OperationFactory();

        var operationService = new OperationInventoryService(PendingCommandService, _repoMock, _idServiceMock, _factoryMock);

        operationService.AddOperationPending(type, bankAccount, amountTest, category, desc);

        PendingCommandService.SaveChanges();

        operationService.UpdateOperationPending(testID);

        Assert.Single(PendingCommandService.UnappliedCommands);
    }

}
