using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.BankAccounts;

public class BankAccountFactory : IBankAccountFactory<BankAccountParams>
{
    public BankAccount CreateBankAccount(BankAccountParams bankAccountParams, int bankAccountID)
    {
        BankAccount bankAccount = new BankAccount(bankAccountID, bankAccountParams);

        return bankAccount;
    }
}
