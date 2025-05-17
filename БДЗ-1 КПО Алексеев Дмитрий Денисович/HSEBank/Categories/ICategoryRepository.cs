using HSEBank.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Categories;

public interface ICategoryRepository
{
    void Add(Category category);

    void Remove(Category category);

    IEnumerable<Category> GetAll();

}
