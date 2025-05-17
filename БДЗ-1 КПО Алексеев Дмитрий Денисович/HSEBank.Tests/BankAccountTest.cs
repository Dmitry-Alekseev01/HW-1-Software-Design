using HSEBank.BankAccounts;
using Xunit;

namespace HSEBank.Tests;

public class BankAccountTest
{
    [Fact]
    public void TestMethod1()
    {
        var bankAccountParams = new BankAccountParams("Dima", 123);
        var bankAccount = new BankAccount(1, bankAccountParams);

        Assert.Equal(1, bankAccount.ID);
    }

    [Fact]
    public void TestMethod2()
    {
        var bankAccountParams = new BankAccountParams("Dima", 123);
        var bankAccount = new BankAccount(1, bankAccountParams);

        Assert.Equal("Dima", bankAccount.BankAccountParams.Name);
    }

    [Fact]
    public void TestMethod3()
    {
        var bankAccountParams = new BankAccountParams("Dima", 123);
        var bankAccount = new BankAccount(1, bankAccountParams);

        Assert.Equal(123, bankAccount.BankAccountParams.Balance);
    }

    [Theory]
    [InlineData(1, "Agil", 123, "Bank account: Number: 1, Name: Agil, Balance: 123")]
    public void TestToString(int id, string name, int balace, string result)
    {
        var bankAccountParams = new BankAccountParams(name, balace);
        var bankAccount = new BankAccount(id, bankAccountParams);

        Assert.True(bankAccount.ToString() == result);
    }

    [Fact]
    public void Constructor_NameIsNull_ThrowsArgumentException()
    {
        string invalidName = null;
        int balance = 100;

        var ex = Assert.Throws<ArgumentException>(() =>
            new BankAccountParams(invalidName, balance));

        Assert.Equal("name", ex.ParamName);
        Assert.Contains("name", ex.Message);
    }

    [Fact]
    public void Constructor_NameIsEmpty_ThrowsArgumentException()
    {
        string invalidName = string.Empty;
        int balance = 100;

        var ex = Assert.Throws<ArgumentException>(() =>
            new BankAccountParams(invalidName, balance));

        Assert.Equal("name", ex.ParamName);
        Assert.Contains("name", ex.Message);
    }
}