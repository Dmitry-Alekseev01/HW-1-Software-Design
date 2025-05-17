using HSEBank.BankAccounts;
using HSEBank.Categories;
using HSEBank.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Tests;

public class OperationTest
{
    [Fact]
    public void TestOperationID()
    {
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima")); 
        var operationParams = new OperationParams(true, bankAccount, 1321, category, "Cool");
        var operation = new Operation(1, operationParams);

        Assert.Equal(1, operation.ID);
    }

    [Fact]
    public void TestOperationTypeTrue()
    {
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(true, bankAccount, 1321, category, "Cool");
        var operation = new Operation(1, operationParams);

        Assert.True(operation.Params.Type);
    }

    [Fact]
    public void TestOperationTypeFalse()
    {
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(false, bankAccount, 1321, category, "Cool");
        var operation = new Operation(1, operationParams);

        Assert.False(operation.Params.Type);
    }

    [Fact]
    public void TestOperationBankAccountId()
    {
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(false, bankAccount, 1321, category, "Cool");
        var operation = new Operation(1, operationParams);

        Assert.Equal(1, operation.Params.BankAccountID);
    }

    [Fact]
    public void TestOperationAmount()
    {
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(false, bankAccount, 1321, category, "Cool");
        var operation = new Operation(1, operationParams);

        Assert.Equal(1321, operation.Params.Amount);
    }

    [Fact]
    public void TestOperationCategoryID()
    {
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(false, bankAccount, 1321, category, "Cool");
        var operation = new Operation(1, operationParams);

        Assert.Equal(1, operation.Params.CategoryID);
    }

    [Fact]
    public void TestOperationDescription()
    {
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(false, bankAccount, 1321, category, "Cool");
        var operation = new Operation(1, operationParams);

        Assert.Equal("Cool", operation.Params.Description);
    }

}
