using HSEBank.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Accounting;

public class GetBankAccountCommand(
    IBankAccountRepository bankAccountRepository,
    int ID
    ) : IAccountingSessionCommand
{
    public void Apply()
    {
        var bankAccount = bankAccountRepository.GetAll().FirstOrDefault(t => t.ID == ID);
        if ( bankAccount == null)
        {
            Console.WriteLine("There is no bank account with this ID.");
        }
        else
        {
            Console.WriteLine(bankAccount.ToString());
        }
    }
}
