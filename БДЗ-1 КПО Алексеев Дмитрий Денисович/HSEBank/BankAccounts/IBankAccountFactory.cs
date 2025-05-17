using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.BankAccounts;

public interface IBankAccountFactory<TParams>
{
    BankAccount CreateBankAccount(TParams BankAccountParams, int BankAccountID);
}
