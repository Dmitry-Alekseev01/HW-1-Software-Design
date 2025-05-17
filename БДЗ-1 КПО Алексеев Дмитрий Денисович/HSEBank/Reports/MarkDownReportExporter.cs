using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HSEBank.Reports;

public sealed class MarkdownReportExporter : ReportExporter
{
    public override void Export(Report report, TextWriter writer)
    {
        writer.WriteLine($"# {report.Title}");
        writer.WriteLine();
        writer.WriteLine(report.Content);
    }
}
