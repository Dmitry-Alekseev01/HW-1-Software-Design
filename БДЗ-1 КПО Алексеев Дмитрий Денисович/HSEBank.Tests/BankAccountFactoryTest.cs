using HSEBank.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HSEBank.Tests;

public class BankAccountFactoryTest
{
    [Fact]
    public void BankAccountFactoryTest1()
    {
        var bankAccountFactory = new BankAccountFactory();
        var bankAccountParams = new BankAccountParams("Agil", 10);
        var bankAccount = bankAccountFactory.CreateBankAccount(bankAccountParams, 1);

        Assert.Equal(1, bankAccount.ID);
    }

    [Fact]
    public void BankAccountFactoryTest2()
    {
        var bankAccountFactory = new BankAccountFactory();
        var bankAccountParams = new BankAccountParams("Agil", 10);
        var bankAccount = bankAccountFactory.CreateBankAccount(bankAccountParams, 1);

        Assert.Equal("Agil", bankAccount.BankAccountParams.Name);
    }

    [Fact]
    public void BankAccountFactoryTest3()
    {
        var bankAccountFactory = new BankAccountFactory();
        var bankAccountParams = new BankAccountParams("Agil", 10);
        var bankAccount = bankAccountFactory.CreateBankAccount(bankAccountParams, 1);

        Assert.Equal(10, bankAccount.BankAccountParams.Balance);
    }

}
