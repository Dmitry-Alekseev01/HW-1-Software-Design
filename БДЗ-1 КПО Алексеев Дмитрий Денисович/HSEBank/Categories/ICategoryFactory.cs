using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Categories;

public interface ICategoryFactory<TParams>
{
    public Category CreateCategory(TParams categoryParams, int ID);
}
