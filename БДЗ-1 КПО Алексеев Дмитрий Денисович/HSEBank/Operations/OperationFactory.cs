using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Operations;

public class OperationFactory : IOperationFactory<OperationParams>
{
    public Operation CreateOperation(OperationParams param, int ID)
    {
        Operation operation = new Operation(ID, param);
        return operation;
    }
}
