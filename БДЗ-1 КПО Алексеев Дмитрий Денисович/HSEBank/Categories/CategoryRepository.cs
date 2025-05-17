using HSEBank.Accounting;
using HSEBank.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Categories;

public class CategoryRepository : ICategoryRepository
{
    private readonly List<Category> categories = new();

    public List<Category> Categories { get { return categories; } }

    public void Add(Category category)
    {
        categories.Add(category);
    }

    public IEnumerable<Category> GetAll()
    {
        return categories.AsReadOnly();
    }

    public void Remove(Category category)
    {
        categories.Remove(category);
    }
}
