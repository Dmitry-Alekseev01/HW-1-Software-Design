using HSEBank.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Operations;

public class OperationIDService(IOperationRepository operationRepository)
{
    public int GetNextNumber() => operationRepository
    .GetAll()
    .Select(c => c.ID)
    .DefaultIfEmpty(0)
    .Max() + 1;
}
