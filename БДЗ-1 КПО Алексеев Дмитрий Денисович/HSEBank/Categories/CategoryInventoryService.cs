using HSEBank.Accounting;
using HSEBank.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Categories;

public class CategoryInventoryService(
    PendingCommandService pendingCommandService,
    ICategoryRepository categoryRepository,
    CategoryIDService categoryIDService,
    CategoryFactory categoryFactory)
{
    public void AddCategoryPending(bool type, string name)
    {
        var command = new AddCategoryCommand(categoryRepository, categoryIDService, categoryFactory, type, name);
        pendingCommandService.AddCommand(command);
    }

    public void RemoveCategoryPending(int ID)
    {
        var command = new DeleteCategoryCommand(categoryRepository, ID);
        pendingCommandService.AddCommand(command);
    }

    public void GetCategoryPending(int ID)
    {
        var command = new GetCategoryCommand(categoryRepository, ID);
        pendingCommandService.AddCommand(command);
    }

    public void UpdateCategoryPending(int ID)
    {
        var command = new UpdateCategoryCommand(categoryRepository, ID);
        pendingCommandService.AddCommand(command);
    }

    public void ShowCategoties()
    {
        var categories = categoryRepository.GetAll().ToList();
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine(categories[i].ToString());
        }
    }
}
