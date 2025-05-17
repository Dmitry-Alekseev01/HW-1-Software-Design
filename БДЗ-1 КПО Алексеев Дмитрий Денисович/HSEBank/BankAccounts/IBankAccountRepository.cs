using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.BankAccounts;

public interface IBankAccountRepository
{
    void Add(BankAccount bankAccount);

    void Remove(BankAccount bankAccount);

    IEnumerable<BankAccount> GetAll();
}
