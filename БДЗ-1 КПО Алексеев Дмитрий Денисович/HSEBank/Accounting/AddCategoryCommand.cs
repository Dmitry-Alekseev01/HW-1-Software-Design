using HSEBank.BankAccounts;
using HSEBank.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Accounting;

public class AddCategoryCommand(
    ICategoryRepository categoryRepository,
    CategoryIDService categoryIDService,
    CategoryFactory categoryFactory,
    bool type,
    string name
        ) : IAccountingSessionCommand
{
    public void Apply()
    {
        int categoryID = categoryIDService.GetNextNumber();
        CategoryParams categoryParams = new CategoryParams(type, name);
        Category bankAccount = categoryFactory.CreateCategory(categoryParams, categoryID);
        categoryRepository.Add(bankAccount);
    }
}
