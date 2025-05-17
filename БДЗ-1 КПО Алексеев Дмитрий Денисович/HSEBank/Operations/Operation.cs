using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HSEBank.BankAccounts;
using HSEBank.Categories;

namespace HSEBank.Operations;

public class Operation
{
    public Operation(int id, OperationParams operationParams)
    {
        ID = id;
        Params = operationParams;
    }

    public int ID
    {
        get;
    }

    public OperationParams Params
    {
        get;
    }


    public override string ToString()
    {
        string type;
        if (Params.Type)
        {
            type = "income";
        }
        else
        {
            type = "consumption";
        }
        return $"Operation: ID: {ID}, Type (income or consumption): {type}, " +
            $"ID of bank account: {Params.BankAccountID}, Sum: {Params.Amount}, Date of operation: {Params.Date} " +
            $"Description: {Params.Description}, ID of category: {Params.CategoryID}";
    }
}