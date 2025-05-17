using HSEBank.BankAccounts;
using HSEBank.Categories;
using HSEBank.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Tests;

public class OperationFactoryTest
{
    [Fact]
    public void TestOperationID()
    {
        var operationFactory = new OperationFactory();
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(true, bankAccount, 1321, category, "Cool");
        var operation = operationFactory.CreateOperation(operationParams, 1);

        Assert.Equal(1, operation.ID);
    }

    [Fact]
    public void TestOperationTypeTrue()
    {
        var operationFactory = new OperationFactory();
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(true, bankAccount, 1321, category, "Cool");
        var operation = operationFactory.CreateOperation(operationParams, 1);

        Assert.True(operation.Params.Type);
    }

    [Fact]
    public void TestOperationTypeFalse()
    {
        var operationFactory = new OperationFactory();
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(false, bankAccount, 1321, category, "Cool");
        var operation = operationFactory.CreateOperation(operationParams, 1);

        Assert.False(operation.Params.Type);
    }

    [Fact]
    public void TestOperationBankAccountId()
    {
        var operationFactory = new OperationFactory();
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(true, bankAccount, 1321, category, "Cool");
        var operation = operationFactory.CreateOperation(operationParams, 1);

        Assert.Equal(1, operation.Params.BankAccountID);
    }

    [Fact]
    public void TestOperationAmount()
    {
        var operationFactory = new OperationFactory();
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(true, bankAccount, 1321, category, "Cool");
        var operation = operationFactory.CreateOperation(operationParams, 1);

        Assert.Equal(1321, operation.Params.Amount);
    }

    [Fact]
    public void TestOperationCategoryID()
    {
        var operationFactory = new OperationFactory();
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(true, bankAccount, 1321, category, "Cool");
        var operation = operationFactory.CreateOperation(operationParams, 1);

        Assert.Equal(1, operation.Params.CategoryID);
    }

    [Fact]
    public void TestOperationDescription()
    {
        var operationFactory = new OperationFactory();
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(true, bankAccount, 1321, category, "Cool");
        var operation = operationFactory.CreateOperation(operationParams, 1);

        Assert.Equal("Cool", operation.Params.Description);
    }

    [Fact]
    public void TestOperationDescriptionEmpty()
    {
        var operationFactory = new OperationFactory();
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(true, bankAccount, 1321, category);
        var operation = operationFactory.CreateOperation(operationParams, 1);

        Assert.Equal(string.Empty, operation.Params.Description);
    }
}
