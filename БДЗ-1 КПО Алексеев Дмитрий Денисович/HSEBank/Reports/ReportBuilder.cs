using HSEBank.BankAccounts;
using HSEBank.Categories;
using HSEBank.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Reports;

public class ReportBuilder
{
    private readonly StringBuilder _content = new();

    public ReportBuilder AddBankAccounts(IEnumerable<BankAccount> bankAccounts)
    {
        _content.AppendLine("Bank accounts:");

        foreach (var bankAccount in bankAccounts)
        {
            _content.AppendLine($"Bank account: Number: {bankAccount.ID}, Name: {bankAccount.BankAccountParams.Name}, Balance: {bankAccount.BankAccountParams.Balance}");
        }

        _content.AppendLine();
        return this;
    }

    public ReportBuilder AddCategories(IEnumerable<Category> categories)
    {
        _content.AppendLine("Categories:");

        foreach (var category in categories)
        {
            _content.AppendLine($"Category: ID: {category.ID}, Name of category: {category.Params.Name}");
            _content.AppendLine();
        }

        return this;
    }

    public ReportBuilder AddOperations(IEnumerable<Operation> operations)
    {
        _content.AppendLine("Operations: ");

        foreach (var operation in operations)
        {
            _content.AppendLine($"Operation: ID: {operation.ID}, ID of bank account: {operation.Params.BankAccountID}, Sum: {operation.Params.Amount}, Date of operation: {operation.Params.Date}, Description: {operation.Params.Description}, ID of category: {operation.Params.CategoryID}");
            _content.AppendLine();
        }

        return this;
    }

    public void ClearReport()
    {
        _content.Clear();
    }

    public Report Build()
    {
        return new Report($"Report for {DateTime.Now:yyyy-MM-dd}", _content.ToString());
    }

}
