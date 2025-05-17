using HSEBank.Accounting;
using HSEBank.BankAccounts;
using HSEBank.Categories;
using HSEBank.Operations;
using HSEBank.Reports;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalCarShop.Reports;

namespace HSEBank;

public class CompositionRoot
{
    private static IServiceProvider? _services;

    public static IServiceProvider? Services => _services ??= CreateServiceProvider();

    private static IServiceProvider CreateServiceProvider()
    {
        var services = new ServiceCollection();
        services.AddSingleton<BankAccountRepository>();
        services.AddSingleton<CategoryRepository>();
        services.AddSingleton<OperationRepository>();
        services.AddSingleton<IBankAccountRepository>(sp => sp.GetRequiredService<BankAccountRepository>());
        services.AddSingleton<ICategoryRepository>(sp => sp.GetRequiredService<CategoryRepository>()); 
        services.AddSingleton<IOperationRepository>(sp => sp.GetRequiredService<OperationRepository>());
        services.AddSingleton<BankAccountFactory>();
        services.AddSingleton<BankAccountInventoryService>();
        services.AddSingleton<BankAccountIDService>();
        services.AddSingleton<CategoryFactory>();
        services.AddSingleton<CategoryInventoryService>();
        services.AddSingleton<CategoryIDService>();
        services.AddSingleton<OperationFactory>();
        services.AddSingleton<OperationInventoryService>();
        services.AddSingleton<OperationIDService>();
        services.AddSingleton<PendingCommandService>();
        services.AddSingleton<ReportsService>();
        services.AddSingleton<ReportBuilder>();

        return services.BuildServiceProvider();
    }

    public static BankAccountInventoryService BankAccountInventoryService { get; } = Services.GetRequiredService<BankAccountInventoryService>();

    public static ReportsService ReportsService { get; } = Services.GetRequiredService<ReportsService>();

    public static PendingCommandService PendingCommandService { get; } = Services.GetRequiredService<PendingCommandService>();

}
