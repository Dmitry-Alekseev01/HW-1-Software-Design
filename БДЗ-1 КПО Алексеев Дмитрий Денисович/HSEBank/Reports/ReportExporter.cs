using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSEBank.Reports;

public abstract class ReportExporter
{
    public abstract void Export(Report report, TextWriter writer);
}
