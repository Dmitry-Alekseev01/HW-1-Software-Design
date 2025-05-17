using HSEBank.Accounting;
using HSEBank.BankAccounts;
using HSEBank.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Tests;

public class CategoryServiceTest
{
    static CategoryRepository _repoMock = new CategoryRepository();
    static CategoryIDService _idServiceMock = new CategoryIDService(_repoMock);
    static CategoryFactory _factoryMock = new CategoryFactory();
    private const bool type = true;
    private const string TestName = "Test Category";
    private const int testID = 1;


    [Fact]
    public void ShouldGenerateAccountAndAddAddCommandToCommandService()
    {
        PendingCommandService PendingCommandService = new PendingCommandService();
        CategoryRepository _repoMock = new CategoryRepository();
        CategoryIDService _idServiceMock = new CategoryIDService(_repoMock);
        CategoryFactory _factoryMock = new CategoryFactory();

        var categoryService = new CategoryInventoryService(PendingCommandService, _repoMock, _idServiceMock, _factoryMock);

        categoryService.AddCategoryPending(type, TestName);

        Assert.Single(PendingCommandService.UnappliedCommands);
    }

    [Fact]
    public void Apply_ShouldGenerateAccountAndAddRemoveCommandToCommandService()
    {
        PendingCommandService PendingCommandService = new PendingCommandService();
        CategoryRepository _repoMock = new CategoryRepository();
        CategoryIDService _idServiceMock = new CategoryIDService(_repoMock);
        CategoryFactory _factoryMock = new CategoryFactory();

        var categoryService = new CategoryInventoryService(PendingCommandService, _repoMock, _idServiceMock, _factoryMock);

        categoryService.AddCategoryPending(type, TestName);

        PendingCommandService.SaveChanges();

        categoryService.RemoveCategoryPending(testID);

        Assert.Single(PendingCommandService.UnappliedCommands);
    }

    [Fact]
    public void Apply_ShouldGenerateAccountAndAddGetCommandToCommandService()
    {
        PendingCommandService PendingCommandService = new PendingCommandService();
        CategoryRepository _repoMock = new CategoryRepository();
        CategoryIDService _idServiceMock = new CategoryIDService(_repoMock);
        CategoryFactory _factoryMock = new CategoryFactory();

        var categoryService = new CategoryInventoryService(PendingCommandService, _repoMock, _idServiceMock, _factoryMock);

        categoryService.AddCategoryPending(type, TestName);

        PendingCommandService.SaveChanges();

        categoryService.GetCategoryPending(testID);

        Assert.Single(PendingCommandService.UnappliedCommands);
    }

    [Fact]
    public void Apply_ShouldGenerateAccountAndAddUpdateCommandToCommandService()
    {
        PendingCommandService PendingCommandService = new PendingCommandService();
        CategoryRepository _repoMock = new CategoryRepository();
        CategoryIDService _idServiceMock = new CategoryIDService(_repoMock);
        CategoryFactory _factoryMock = new CategoryFactory();

        var categoryService = new CategoryInventoryService(PendingCommandService, _repoMock, _idServiceMock, _factoryMock);

        categoryService.AddCategoryPending(type, TestName);

        PendingCommandService.SaveChanges();

        categoryService.UpdateCategoryPending(testID);

        Assert.Single(PendingCommandService.UnappliedCommands);
    }
}
