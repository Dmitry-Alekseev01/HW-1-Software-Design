using HSEBank.BankAccounts;
using HSEBank.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Operations;


public record OperationParams
{
    public OperationParams(bool type, BankAccount bankAccount, int amount, Category category, string description = "")
    {
        Type = type;
        BankAccountID = bankAccount.ID;
        Amount = amount;
        Date = DateTime.Now;
        Description = description;
        CategoryID = category.ID;
    }

    public bool Type
    {
        get;
    }

    public int BankAccountID
    {
        get;
    }

    public int Amount { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; } = string.Empty;

    public int CategoryID
    {
        get;
    }
}
