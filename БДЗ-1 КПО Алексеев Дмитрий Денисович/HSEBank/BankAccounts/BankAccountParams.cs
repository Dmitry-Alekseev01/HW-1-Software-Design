using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.BankAccounts;

public record BankAccountParams
{
    public string Name { get; set; }

    public int Balance { get; set; }

    public BankAccountParams(string name, int balance)
    {
        if (name == null || name == string.Empty)
        {
            throw new ArgumentException("name", nameof(name));
        }

        Name = name;

        Balance = balance;
    }
}