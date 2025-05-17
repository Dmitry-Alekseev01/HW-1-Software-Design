using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.BankAccounts;

public class BankAccount
{
    public BankAccount(int id, BankAccountParams bankAccountParams)
    {
        ID = id;
        BankAccountParams = bankAccountParams;
    }

    public int ID
    {
        get;
    }

    public BankAccountParams BankAccountParams { get; }

    public override string ToString()
    {
        return $"Bank account: Number: {ID}, Name: {BankAccountParams.Name}, Balance: {BankAccountParams.Balance}";
    }
}
