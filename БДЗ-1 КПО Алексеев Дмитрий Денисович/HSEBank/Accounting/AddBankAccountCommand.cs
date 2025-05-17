using HSEBank.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Accounting;

public class AddBankAccountCommand(
    IBankAccountRepository bankAccountRepository,
    BankAccountIDService bankAccountIDService,
    BankAccountFactory bankAccountFactory,
    string name, 
    int balance
    ) : IAccountingSessionCommand
{
    public void Apply()
    {
        int bankAccountID = bankAccountIDService.GetNextNumber();
        BankAccountParams bankAccountParams = new BankAccountParams(name, balance);
        BankAccount bankAccount = bankAccountFactory.CreateBankAccount(bankAccountParams, bankAccountID);
        bankAccountRepository.Add(bankAccount);
    }

    public override string ToString() => $"Bank account added. Name: {name}. Balance: {balance}.";
}
