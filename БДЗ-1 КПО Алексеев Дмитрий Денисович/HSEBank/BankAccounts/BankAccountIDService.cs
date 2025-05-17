using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.BankAccounts;

public class BankAccountIDService(IBankAccountRepository bankAccountRepository)
{
    public int GetNextNumber() => bankAccountRepository
        .GetAll()
        .Select(c => c.ID)
        .DefaultIfEmpty(0)
        .Max() + 1;
}
