using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Categories;

public class Category
{
    public Category(int id, CategoryParams categoryParams)
    {
        ID = id;
        Params = categoryParams;
    }

    public int ID { get; }

    public CategoryParams Params { get; }

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
        return $"Category: ID: {ID}, Type (income or consumption): {type}, Name of category: {Params.Name}";
    }
}
