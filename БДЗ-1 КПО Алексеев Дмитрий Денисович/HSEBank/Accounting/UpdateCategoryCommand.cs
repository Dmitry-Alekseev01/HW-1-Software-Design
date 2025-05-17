using HSEBank.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSEBank.Categories;

namespace HSEBank.Accounting;

public class UpdateCategoryCommand(
    ICategoryRepository categoryRepository,
    int ID
    ) : IAccountingSessionCommand
{
    public void Apply()
    {
        var category = categoryRepository.GetAll().FirstOrDefault(t => t.ID == ID);
        if (category == null) {
            Console.WriteLine("No category with this ID.");
            return;
        }
        Console.WriteLine("What do you want to change?");
        Console.WriteLine("1 - change type.");
        Console.WriteLine("2 - change name.");
        int choice = Program.InputNumber(1, 2);
        switch (choice)
        {
            case 1:
                Console.WriteLine("Input type of category: ");
                Console.WriteLine("1 - income.");
                Console.WriteLine("2 - consumption.");
                int choice_type = Program.InputNumber(1, 2);
                switch (choice_type)
                {
                    case 1:
                        category.Params.Type = true;
                        break;
                    case 2:
                        category.Params.Type = false;
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                Console.WriteLine("Input new name: ");
                string name = Program.InputString();
                category.Params.Name = name;
                break;
            default:
                break;
        }

    }
}
