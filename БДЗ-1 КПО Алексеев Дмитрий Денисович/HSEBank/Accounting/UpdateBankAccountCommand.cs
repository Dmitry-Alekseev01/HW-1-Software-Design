using HSEBank.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Accounting;

public class UpdateBankAccountCommand(
    IBankAccountRepository bankAccountRepository,
    int ID) : IAccountingSessionCommand
{
    public void Apply()
    {
        var bankAccount = bankAccountRepository.GetAll().FirstOrDefault(t => t.ID == ID);
        if (bankAccount == null)
        {
            Console.WriteLine("No Bank account with this ID.");
            return;
        }
        Console.WriteLine("What do you want to change?");
        Console.WriteLine("1 - change name.");
        Console.WriteLine("2 - change balance.");
        int choice = Program.InputNumber(1, 2);
        switch (choice)
        {
            case 1:
                Console.WriteLine("Input new name: ");
                string? name = Program.InputString();
                bankAccount.BankAccountParams.Name = name;
                break;
            case 2:
                Console.WriteLine("Input amount of money: ");
                int amount = Program.InputMoreThanZero();
                Console.WriteLine("1 - put money.");
                Console.WriteLine("2 - take money.");
                int choice_amount = Program.InputNumber(1, 2);
                switch (choice_amount)
                {
                    case 1:
                        bankAccount.BankAccountParams.Balance += amount;
                        break;
                    case 2:
                        if(bankAccount.BankAccountParams.Balance > 0 && amount < bankAccount.BankAccountParams.Balance)
                        {
                            bankAccount.BankAccountParams.Balance -= amount;
                        }
                        else
                        {
                            Console.WriteLine("You can't take money.");
                        }
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
}
