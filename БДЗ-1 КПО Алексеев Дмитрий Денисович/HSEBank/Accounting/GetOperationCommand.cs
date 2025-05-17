using HSEBank.Categories;
using HSEBank.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Accounting;

public class GetOperationCommand(
    IOperationRepository operationRepository,
    int ID) : IAccountingSessionCommand
{
    public void Apply()
    {
        Operation? operation = operationRepository.GetAll().FirstOrDefault(c => c.ID == ID);
        if (operation == null)
        {
            Console.WriteLine("No operation with this ID.");
        }
        else {
            Console.WriteLine(operation.ToString());
        }
    }
}