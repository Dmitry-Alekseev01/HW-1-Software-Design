using HSEBank.Accounting;
using HSEBank.BankAccounts;
using HSEBank.Categories;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Tests;

public class CategoryCommandsTest
{
    private const string TestName = "Test Category";
    private const bool TestType = true;
    private const int testID = 1;

    [Fact]
    public void AddCommandApplyTest()
    {
        CategoryRepository _repoMock = new CategoryRepository();
        CategoryIDService _idServiceMock = new CategoryIDService(_repoMock);
        CategoryFactory _factoryMock = new CategoryFactory();

        var command = new AddCategoryCommand(_repoMock, _idServiceMock, _factoryMock, TestType, TestName);
        command.Apply();

        var categories = _repoMock.GetAll().ToList();

        Assert.Single(categories);
    }

    [Fact]
    public void AddCommandApply2Test()
    {
        CategoryRepository _repoMock = new CategoryRepository();
        CategoryIDService _idServiceMock = new CategoryIDService(_repoMock);
        CategoryFactory _factoryMock = new CategoryFactory();

        var command = new AddCategoryCommand(_repoMock, _idServiceMock, _factoryMock, TestType, TestName);
        command.Apply();
        var command1 = new AddCategoryCommand(_repoMock, _idServiceMock, _factoryMock, TestType, TestName);
        command1.Apply();


        var categories = _repoMock.GetAll().ToList();

        Assert.Equal(2, categories.Count);
    }

    [Fact]
    public void RemoveCommandApplyTest()
    {
        CategoryRepository _repoMock = new CategoryRepository();
        CategoryIDService _idServiceMock = new CategoryIDService(_repoMock);
        CategoryFactory _factoryMock = new CategoryFactory();

        var command = new AddCategoryCommand(_repoMock, _idServiceMock, _factoryMock, TestType, TestName);
        command.Apply();
        var command1 = new DeleteCategoryCommand(_repoMock, testID);
        command1.Apply();


        var categories = _repoMock.GetAll().ToList();

        Assert.Empty(categories);
    }
}
