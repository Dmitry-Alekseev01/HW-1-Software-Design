using HSEBank.BankAccounts;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Tests;

public class BankAccountIDServiceTest
{
    [Fact]
    public void GetNextNumberTest()
    {
        var bankAccountParams = new BankAccountParams("Dima", 123);
        var bankAccount = new BankAccount(1, bankAccountParams);

        var bankAccountRepository = new BankAccountRepository();

        var bankAccountIDService = new BankAccountIDService(bankAccountRepository);

        bankAccountRepository.BankAccounts.Add(bankAccount);

        int id = bankAccountIDService.GetNextNumber();

        Assert.Equal(2, id);
    }

    [Fact]
    public void GetNextNumberTest2()
    {
        var bankAccountParams = new BankAccountParams("Dima", 123);
        var bankAccount = new BankAccount(1, bankAccountParams);

        var bankAccountParams1 = new BankAccountParams("Dima", 123);
        var bankAccount1 = new BankAccount(2, bankAccountParams);


        var bankAccountRepository = new BankAccountRepository();

        var bankAccountIDService = new BankAccountIDService(bankAccountRepository);

        bankAccountRepository.BankAccounts.Add(bankAccount);
        bankAccountRepository.BankAccounts.Add(bankAccount1);

        bankAccountRepository.BankAccounts.Remove(bankAccount);

        int id = bankAccountIDService.GetNextNumber();

        Assert.Equal(3, id);
    }

    [Fact]
    public void GetNextNumberTest3()
    {
        var bankAccountParams = new BankAccountParams("Dima", 123);
        var bankAccount = new BankAccount(1, bankAccountParams);

        var bankAccountParams1 = new BankAccountParams("Dima", 123);
        var bankAccount1 = new BankAccount(2, bankAccountParams);


        var bankAccountRepository = new BankAccountRepository();

        var bankAccountIDService = new BankAccountIDService(bankAccountRepository);

        bankAccountRepository.BankAccounts.Add(bankAccount);
        bankAccountRepository.BankAccounts.Add(bankAccount1);

        bankAccountRepository.BankAccounts.Remove(bankAccount);
        bankAccountRepository.BankAccounts.Remove(bankAccount1);

        int id = bankAccountIDService.GetNextNumber();

        Assert.Equal(1, id);
    }

}
