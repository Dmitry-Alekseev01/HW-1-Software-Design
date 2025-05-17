using HSEBank.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Accounting;

public class GetCategoryCommand(
    ICategoryRepository categoryRepository,
    int ID) : IAccountingSessionCommand
{
    public void Apply()
    {
        Category? category = categoryRepository.GetAll().FirstOrDefault(c => c.ID == ID);
        if (category == null) {
            Console.WriteLine("No category with this ID.");
        }
        else
        {
            Console.WriteLine(category.ToString());
        }
    }
}
