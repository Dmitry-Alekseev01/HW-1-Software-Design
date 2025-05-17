using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Reports;

public record Report(string Title, string Content)
{
    public override string ToString()
    {
        return $"{Title}\n\n{Content}";
    }
}