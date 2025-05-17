using HSEBank.BankAccounts;
using HSEBank.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Tests;

public class CategoryFactoryTest
{
    [Fact]
    public void BankAccountFactoryTest1()
    {
        var categoryFactory = new CategoryFactory();
        var categorytParams = new CategoryParams(true, "Agil");
        var category = categoryFactory.CreateCategory(categorytParams, 1);

        Assert.Equal(1, category.ID);
    }

    [Fact]
    public void BankAccountFactoryTest2()
    {
        var categoryFactory = new CategoryFactory();
        var categorytParams = new CategoryParams(true, "Agil");
        var category = categoryFactory.CreateCategory(categorytParams, 1);

        Assert.Equal("Agil", category.Params.Name);
    }

    [Fact]
    public void BankAccountFactoryTest3()
    {
        var categoryFactory = new CategoryFactory();
        var categorytParams = new CategoryParams(true, "Agil");
        var category = categoryFactory.CreateCategory(categorytParams, 1);

        Assert.True(category.Params.Type);
    }

}
