using HSEBank.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Operations;

public interface IOperationRepository
{
    void Add(Operation operation);

    void Remove(Operation operation);

    IEnumerable<Operation> GetAll();
}
