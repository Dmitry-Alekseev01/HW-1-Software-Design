using HSEBank.Categories;
using HSEBank.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Accounting;

public class UpdateOperationCommand(
     IOperationRepository operationRepository,
     int ID
        ) : IAccountingSessionCommand
{
    public void Apply()
    {
        var operation = operationRepository.GetAll().FirstOrDefault(t => t.ID == ID);
        if (operation == null) {
            Console.WriteLine("No operation with this ID.");
            return;
        }
        Console.WriteLine("What do you want to change?");
        Console.WriteLine("1 - change description.");
        int choice = Program.InputNumber(1, 1);
        switch (choice)
        {
            case 1:
                Console.WriteLine("Input new description: ");
                operation.Params.Description = Console.ReadLine();
                break;
            default:
                break;
        }
    }
}
