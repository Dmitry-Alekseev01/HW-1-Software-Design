using HSEBank.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.BankAccounts;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly List<BankAccount> bankAccounts = new();

    public List<BankAccount> BankAccounts { get { return  bankAccounts; } } 

    public void Add(BankAccount bankAccount)
    {
        bankAccounts.Add(bankAccount);
    }

    public void Remove(BankAccount bankAccount)
    {
        bankAccounts.Remove(bankAccount);
    }

    public IEnumerable<BankAccount> GetAll()
    {
        return bankAccounts.AsReadOnly();
    }
}
