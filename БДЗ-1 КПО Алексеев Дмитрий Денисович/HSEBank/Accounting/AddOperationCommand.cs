using HSEBank.BankAccounts;
using HSEBank.Categories;
using HSEBank.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Accounting;

public class AddOperationCommand(
    IOperationRepository operationRepository,
    OperationIDService operationIDService,
    OperationFactory operationFactory,
    bool type,
    BankAccount bankAccount, 
    int amount,
    Category category,
    string description = ""
    ) : IAccountingSessionCommand
{
    public void Apply()
    {
        int bankAccountID = operationIDService.GetNextNumber();
        OperationParams operationParams = new OperationParams(type, bankAccount, amount, category, description);
        Operation operation = operationFactory.CreateOperation(operationParams, bankAccountID);
        operationRepository.Add(operation);
    }

}