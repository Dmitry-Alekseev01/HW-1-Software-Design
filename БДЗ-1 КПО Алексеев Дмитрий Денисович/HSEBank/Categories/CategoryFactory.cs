using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Categories;

public class CategoryFactory : ICategoryFactory<CategoryParams>
{
    public Category CreateCategory(CategoryParams categoryParams, int ID)
    {
        Category category = new Category(ID, categoryParams);

        return category;
    }
}
