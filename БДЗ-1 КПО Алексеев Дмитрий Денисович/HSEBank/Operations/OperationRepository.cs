using HSEBank.Accounting;
using HSEBank.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Operations;

public class OperationRepository : IOperationRepository
{
    private readonly List<Operation> operations = new();

    public List<Operation> Operations { get { return operations; } }

    public void Add(Operation operation)
    {
        operations.Add(operation);
    }

    public IEnumerable<Operation> GetAll()
    {
        return operations.AsReadOnly();
    }

    public void Remove(Operation operation)
    {
        operations.Remove(operation);
    }

}
