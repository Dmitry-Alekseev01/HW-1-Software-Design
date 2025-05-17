using HSEBank.BankAccounts;
using HSEBank.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Tests;

public class CategoryIDServiceTest
{
    [Fact]
    public void GetNextNumberTest()
    {
        var categoryParams = new CategoryParams(true, "Dima");
        var category = new Category(1, categoryParams);

        var categoryRepository = new CategoryRepository();

        var categoryIDService = new CategoryIDService(categoryRepository);

        categoryRepository.Categories.Add(category);

        int id = categoryIDService.GetNextNumber();

        Assert.Equal(2, id);
    }

    [Fact]
    public void GetNextNumberTest2()
    {
        var categoryParams = new CategoryParams(true, "Dima");
        var category = new Category(1, categoryParams);

        var categoryParams1 = new CategoryParams(true, "Dima");
        var category1 = new Category(2, categoryParams);


        var categoryRepository = new CategoryRepository();

        var categoryIDService = new CategoryIDService(categoryRepository);

        categoryRepository.Categories.Add(category);
        categoryRepository.Categories.Add(category1);

        categoryRepository.Categories.Remove(category);

        int id = categoryIDService.GetNextNumber();

        Assert.Equal(3, id);
    }

    [Fact]
    public void GetNextNumberTest3()
    {
        var categoryParams = new CategoryParams(true, "Dima");
        var category = new Category(1, categoryParams);

        var categoryParams1 = new CategoryParams(true, "Dima");
        var category1 = new Category(2, categoryParams);


        var categoryRepository = new CategoryRepository();

        var categoryIDService = new CategoryIDService(categoryRepository);

        categoryRepository.Categories.Add(category);
        categoryRepository.Categories.Add(category1);

        categoryRepository.Categories.Remove(category);
        categoryRepository.Categories.Remove(category1);

        int id = categoryIDService.GetNextNumber();

        Assert.Equal(1, id);
    }
}
