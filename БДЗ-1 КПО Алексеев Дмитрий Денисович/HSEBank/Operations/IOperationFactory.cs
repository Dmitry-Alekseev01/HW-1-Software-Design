using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Operations;

public interface IOperationFactory<TParams>
{
    public Operation CreateOperation(TParams param, int ID);
}
