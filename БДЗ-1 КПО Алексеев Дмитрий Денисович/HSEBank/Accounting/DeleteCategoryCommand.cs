using HSEBank.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Accounting;

public class DeleteCategoryCommand(
     ICategoryRepository categoryRepository,
     int ID
        ) : IAccountingSessionCommand
{
    public void Apply()
    {
        Category? category = categoryRepository.GetAll().FirstOrDefault(c => c.ID == ID);
        if (category != null)
        {
            categoryRepository.Remove(category);
        }
        else
        {
            Console.WriteLine("There is no category with this ID.");
        }
    }
}
