using HSEBank.BankAccounts;
using HSEBank.Categories;
using HSEBank.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Tests;

public class OperationRepositoryTest
{
    [Fact]
    public void GetInventory_AfterAddingAdding_ReturnsCorrectList()
    {
        // Arrange
        var storage = new OperationRepository();
        var bankAccount1 = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category1 = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams1 = new OperationParams(false, bankAccount1, 1321, category1, "Cool");
        var inventory1 = new Operation(1, operationParams1);

        var bankAccount2 = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category2 = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams2 = new OperationParams(false, bankAccount2, 1321, category2, "Cool");
        var inventory2 = new Operation(2, operationParams2);

        storage.Add(inventory1);
        storage.Add(inventory2);

        // Act
        var result = storage.GetAll().ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Contains(inventory1, result);
        Assert.Contains(inventory2, result);
    }


    [Fact]
    public void GetInventory_AfterAddingAccountAndDeleting_ReturnsCorrectList()
    {
        // Arrange
        var storage = new OperationRepository();
        var bankAccount1 = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category1 = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams1 = new OperationParams(false, bankAccount1, 1321, category1, "Cool");
        var inventory1 = new Operation(1, operationParams1);

        var bankAccount2 = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category2 = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams2 = new OperationParams(false, bankAccount2, 1321, category2, "Cool");
        var inventory2 = new Operation(2, operationParams2);

        storage.Add(inventory1);
        storage.Add(inventory2);

        storage.Remove(inventory1);

        // Act
        var result = storage.GetAll().ToList();

        // Assert
        Assert.Single(result);
        Assert.DoesNotContain(inventory1, result);
        Assert.Contains(inventory2, result);
    }

    [Fact]
    public void GetInventory_AfterAddingNothing_ReturnsCorrectList()
    {
        // Arrange
        var storage = new OperationRepository();

        // Act
        var result = storage.GetAll().ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetInventory_AfterAddingAccountAndDeleting2_ReturnsCorrectList()
    {
        // Arrange
        var storage = new OperationRepository();
        var bankAccount1 = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category1 = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams1 = new OperationParams(false, bankAccount1, 1321, category1, "Cool");
        var inventory1 = new Operation(1, operationParams1);

        var bankAccount2 = new BankAccount(1, new BankAccountParams("Agil", 123));
        var category2 = new Category(1, new CategoryParams(true, "Dima"));
        var operationParams2 = new OperationParams(false, bankAccount2, 1321, category2, "Cool");
        var inventory2 = new Operation(2, operationParams2);

        storage.Operations.Add(inventory1);
        storage.Operations.Add(inventory2);

        storage.Operations.Remove(inventory1);

        // Assert
        Assert.Single(storage.Operations);
        Assert.DoesNotContain(inventory1, storage.Operations);
        Assert.Contains(inventory2, storage.Operations);
    }

    [Fact]
    public void BankAccounts_InitializedAsEmpty()
    {
        // Arrange & Act
        var repository = new OperationRepository();

        // Assert
        Assert.Empty(repository.Operations);
    }


}
