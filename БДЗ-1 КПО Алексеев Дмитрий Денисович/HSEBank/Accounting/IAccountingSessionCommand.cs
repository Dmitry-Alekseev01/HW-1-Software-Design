using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Accounting;

public interface IAccountingSessionCommand
{
    void Apply();
}
