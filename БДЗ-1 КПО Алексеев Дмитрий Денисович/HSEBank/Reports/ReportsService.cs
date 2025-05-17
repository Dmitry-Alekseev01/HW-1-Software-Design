using HSEBank.Categories;
using HSEBank.BankAccounts;
using HSEBank.Operations;
using HSEBank.Reports;

namespace UniversalCarShop.Reports;
public sealed class ReportsService
{
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IOperationRepository _operationRepository;
    private readonly ReportBuilder _reportBuilder;

    public ReportsService(
        IBankAccountRepository bankAccountRepository,
        ICategoryRepository categoryRepository,
        IOperationRepository operationRepository,
        ReportBuilder reportBuilder
        )
    {
        _bankAccountRepository = bankAccountRepository;
        _categoryRepository = categoryRepository;
        _operationRepository = operationRepository;
        _reportBuilder = reportBuilder;
    }

    public Report GetCurrentReport()
    {
        var bankAccounts = _bankAccountRepository.GetAll();
        var categories = _categoryRepository.GetAll();
        var operations = _operationRepository.GetAll();

        return _reportBuilder
            .AddBankAccounts(bankAccounts)
            .AddCategories(categories)
            .AddOperations(operations)
            .Build();
    }
    public void ExportReport(TextWriter writer)
    {
        if (writer == null)
            throw new ArgumentNullException(nameof(writer));

        var report = GetCurrentReport();

        var exporter = new MarkdownReportExporter();

        exporter.Export(report, writer);

        _reportBuilder.ClearReport();
    }
}