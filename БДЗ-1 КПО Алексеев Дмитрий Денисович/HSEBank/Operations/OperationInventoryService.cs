using HSEBank.Accounting;
using HSEBank.BankAccounts;
using HSEBank.Categories;
using HSEBank.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Operations;

public class OperationInventoryService(
    PendingCommandService pendingCommandService,
    IOperationRepository operationRepository,
    OperationIDService operationIDService,
    OperationFactory operationFactory)
{
    public void AddOperationPending(bool type, BankAccount bankAccount, int amount, Category category, string description = "")
    {
        var command = new AddOperationCommand(operationRepository, operationIDService, operationFactory, type, bankAccount, amount, category, description);
        pendingCommandService.AddCommand(command);
    }

    public void RemoveOperationPending(int ID)
    {
        var command = new DeleteOperationCommand(operationRepository, ID);
        pendingCommandService.AddCommand(command);
    }

    public void GetOperationPending(int ID)
    {
        var command = new GetOperationCommand(operationRepository, ID);
        pendingCommandService.AddCommand(command);
    }

    public void UpdateOperationPending(int ID)
    {
        var command = new UpdateOperationCommand(operationRepository, ID);
        pendingCommandService.AddCommand(command);
    }

    public void ShowOperations()
    {
        var categories = operationRepository.GetAll().ToList();
        for (int i = 0; i < categories.Count; i++) 
        {
            Console.WriteLine(categories[i].ToString());
        }
    }
}