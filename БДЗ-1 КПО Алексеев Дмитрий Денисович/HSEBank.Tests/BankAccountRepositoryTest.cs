using HSEBank.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Tests;

public class BankAccountRepositoryTest
{
    [Fact]
    public void GetInventory_AfterAddingAdding_ReturnsCorrectList()
    {
        // Arrange
        var storage = new BankAccountRepository();
        var inventory1 = new BankAccount(1, new BankAccountParams("Agil", 123));
        var inventory2 = new BankAccount(2, new BankAccountParams("Agil", 123));

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
        var storage = new BankAccountRepository();
        var inventory1 = new BankAccount(1, new BankAccountParams("Agil", 123));
        var inventory2 = new BankAccount(2, new BankAccountParams("Agil", 123));

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
        var storage = new BankAccountRepository();

        // Act
        var result = storage.GetAll().ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetInventory_AfterAddingAccountAndDeleting2_ReturnsCorrectList()
    {
        // Arrange
        var storage = new BankAccountRepository();
        var inventory1 = new BankAccount(1, new BankAccountParams("Agil", 123));
        var inventory2 = new BankAccount(2, new BankAccountParams("Agil", 123));

        storage.BankAccounts.Add(inventory1);
        storage.BankAccounts.Add(inventory2);

        storage.BankAccounts.Remove(inventory1);

        // Assert
        Assert.Single(storage.BankAccounts);
        Assert.DoesNotContain(inventory1, storage.BankAccounts);
        Assert.Contains(inventory2, storage.BankAccounts);
    }

    [Fact]
    public void BankAccounts_InitializedAsEmpty()
    {
        // Arrange & Act
        var repository = new BankAccountRepository();

        // Assert
        Assert.Empty(repository.BankAccounts);
    }
}