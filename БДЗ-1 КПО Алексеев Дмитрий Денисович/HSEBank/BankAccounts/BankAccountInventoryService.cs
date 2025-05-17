using HSEBank.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.BankAccounts;

public class BankAccountInventoryService(
    PendingCommandService pendingCommandService,
    IBankAccountRepository bankAccountRepository,
    BankAccountIDService bankAccountIDService,
    BankAccountFactory bankAccountFactory)
{
    public void AddBankAccountPending(string name, int balance)
    {
        var command = new AddBankAccountCommand(bankAccountRepository, bankAccountIDService, bankAccountFactory, name, balance);
        pendingCommandService.AddCommand(command);
    }

    public void RemoveBankAccountPending(int ID) {
        var command = new DeleteBankAccountCommand(bankAccountRepository, ID);
        pendingCommandService.AddCommand(command);
    }

    public void GetBankAccountPending(int ID)
    {
        var command = new GetBankAccountCommand(bankAccountRepository, ID);
        pendingCommandService.AddCommand(command);
    }

    public void UpdateBankAccountPending(int ID)
    {
        var command = new UpdateBankAccountCommand(bankAccountRepository, ID);
        pendingCommandService.AddCommand(command);
    }

    public void ShowAccounts()
    {
        List<BankAccount> bankAccounts = bankAccountRepository.GetAll().ToList();
        for (int i = 0; i < bankAccounts.Count; i++) {
            Console.WriteLine(bankAccounts[i].ToString());
        }
    }
}