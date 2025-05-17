using HSEBank.BankAccounts;
using HSEBank.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Tests;

public class CategoryRepositoryTest
{
    [Fact]
    public void GetInventory_AfterAddingAdding_ReturnsCorrectList()
    {
        // Arrange
        var storage = new CategoryRepository();
        var inventory1 = new Category(1, new CategoryParams(true, "Agil"));
        var inventory2 = new Category(2, new CategoryParams(false, "Kirill"));

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
        var storage = new CategoryRepository();
        var inventory1 = new Category(1, new CategoryParams(true, "Agil"));
        var inventory2 = new Category(2, new CategoryParams(false, "Kirill"));

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
        var storage = new CategoryRepository();

        // Act
        var result = storage.GetAll().ToList();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetInventory_AfterAddingAccountAndDeleting2_ReturnsCorrectList()
    {
        // Arrange
        var storage = new CategoryRepository();
        var inventory1 = new Category(1, new CategoryParams(true, "Agil"));
        var inventory2 = new Category(2, new CategoryParams(false, "Kirill"));

        storage.Categories.Add(inventory1);
        storage.Categories.Add(inventory2);

        storage.Categories.Remove(inventory1);

        // Assert
        Assert.Single(storage.Categories);
        Assert.DoesNotContain(inventory1, storage.Categories);
        Assert.Contains(inventory2, storage.Categories);
    }

    [Fact]
    public void BankAccounts_InitializedAsEmpty()
    {
        // Arrange & Act
        var repository = new CategoryRepository();

        // Assert
        Assert.Empty(repository.Categories);
    }

}
