using HSEBank.BankAccounts;
using HSEBank.Categories;
using HSEBank.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Tests;

public class OperationIDServiceTest
{
    [Fact]
    public void GetNextNumberTest()
    {
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(true, bankAccount, 1321, category, "Cool");
        var operation = new Operation(1, operationParams);

        var operationRepository = new OperationRepository();

        var operationIDService = new OperationIDService(operationRepository);

        operationRepository.Operations.Add(operation);

        int id = operationIDService.GetNextNumber();

        Assert.Equal(2, id);
    }

    [Fact]
    public void GetNextNumberTest2()
    {
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(true, bankAccount, 1321, category, "Cool");
        var operation = new Operation(1, operationParams);

        var bankAccount1 = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category1 = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams1 = new OperationParams(true, bankAccount1, 1321, category1, "Cool");
        var operation1 = new Operation(2, operationParams1);

        var operationRepository = new OperationRepository();

        var operationIDService = new OperationIDService(operationRepository);

        operationRepository.Operations.Add(operation);
        operationRepository.Operations.Add(operation1);

        operationRepository.Operations.Remove(operation);

        int id = operationIDService.GetNextNumber();

        Assert.Equal(3, id);
    }

    [Fact]
    public void GetNextNumberTest3()
    {
        var bankAccount = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams = new OperationParams(true, bankAccount, 1321, category, "Cool");
        var operation = new Operation(1, operationParams);

        var bankAccount1 = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category1 = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams1 = new OperationParams(true, bankAccount1, 1321, category1, "Cool");
        var operation1 = new Operation(2, operationParams1);

        var operationRepository = new OperationRepository();

        var operationIDService = new OperationIDService(operationRepository);

        operationRepository.Operations.Add(operation);
        operationRepository.Operations.Add(operation1);

        operationRepository.Operations.Remove(operation);
        operationRepository.Operations.Remove(operation1);

        int id = operationIDService.GetNextNumber();

        Assert.Equal(1, id);
    }

}
