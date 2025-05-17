using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Categories;

public record CategoryParams
{
    public bool Type { get; set; }

    public string Name { get; set; }

    public CategoryParams(bool type, string name) {
        if (name == null || name == string.Empty)
        {
            throw new ArgumentException("name", nameof(name));
        }

        Type = type;
        Name = name;
    }

}