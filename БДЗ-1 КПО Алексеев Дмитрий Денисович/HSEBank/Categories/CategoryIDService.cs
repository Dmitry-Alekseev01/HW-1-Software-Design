using HSEBank.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Categories;

public class CategoryIDService(ICategoryRepository categoryRepository)
{
    public int GetNextNumber() => categoryRepository
        .GetAll()
        .Select(c => c.ID)
        .DefaultIfEmpty(0)
        .Max() + 1;
}
