using HSEBank.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSEBank.Accounting;

public class DeleteBankAccountCommand(
    IBankAccountRepository bankAccountRepository,
    int ID
    ) : IAccountingSessionCommand
{
    public void Apply()
    {
        var bankAccount = bankAccountRepository.GetAll().FirstOrDefault(c => c.ID == ID);
        if (bankAccount == null)
        {
            Console.WriteLine("No ID like this.");
        }
        else
        {
            bankAccountRepository.Remove(bankAccount);
        }
    }

    public override string ToString()
    {
        return $"Bank account deleted.";
    }
}
