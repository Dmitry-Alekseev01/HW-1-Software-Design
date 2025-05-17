using HSEBank.BankAccounts;
using HSEBank.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Tests;

public class CategoryTest
{
    [Fact]
    public void TestCategoryID()
    {
        var categoryParams = new CategoryParams(true, "Agil");
        var category = new Category(1, categoryParams);

        Assert.Equal(1, category.ID);
    }

    [Fact]
    public void TestCategoryTypeTrue()
    {
        var categoryParams = new CategoryParams(true, "Agil");
        var category = new Category(1, categoryParams);

        Assert.True(categoryParams.Type);
    }

    [Fact]
    public void TestCategoryTypeFalse()
    {
        var categoryParams = new CategoryParams(false, "Agil");
        var category = new Category(1, categoryParams);

        Assert.False(categoryParams.Type);
    }


    [Fact]
    public void TestCategoryName()
    {
        var categoryParams = new CategoryParams(true, "Agil");
        var category = new Category(1, categoryParams);

        Assert.Equal("Agil", category.Params.Name);
    }

    [Theory]
    [InlineData(1, true, "Agil", "Category: ID: 1, Type (income or consumption): income, Name of category: Agil")]
    public void TestToString(int id, bool type, string name, string result)
    {
        var categoryParams = new CategoryParams(type, name);
        var category = new Category(id, categoryParams);

        Assert.True(category.ToString() == result);
    }

    [Fact]
    public void Constructor_NameIsNull_ThrowsArgumentException()
    {
        string invalidName = null;
        bool type = true;

        var ex = Assert.Throws<ArgumentException>(() =>
            new CategoryParams(type, invalidName));

        Assert.Equal("name", ex.ParamName);
        Assert.Contains("name", ex.Message);
    }

    [Fact]
    public void Constructor_NameIsEmpty_ThrowsArgumentException()
    {
        string invalidName = string.Empty;
        bool type = true;

        var ex = Assert.Throws<ArgumentException>(() =>
            new CategoryParams(type, invalidName));

        Assert.Equal("name", ex.ParamName);
        Assert.Contains("name", ex.Message);
    }

}
