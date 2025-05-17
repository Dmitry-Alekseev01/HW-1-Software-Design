using HSEBank;
using HSEBank.Accounting;
using HSEBank.BankAccounts;
using HSEBank.Categories;
using HSEBank.Operations;
using HSEBank.Reports;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static int InputNumber()
    {
        int n;
        bool check;
        do
        {
            check = int.TryParse(Console.ReadLine(), out n);
            if (!check)
            {
                Console.WriteLine("Input integer");
            }
        }
        while (!check);

        return n;
    }

    public static string InputString()
    {
        string n;
        bool check;
        do
        {
            n = Console.ReadLine();
            check = string.IsNullOrEmpty(n);
            if (check)
            {
                Console.WriteLine("Input not null or not empty");
            }
        }
        while (check);

        return n;
    }


    public static int InputNumber(int start, int end)
    {
        int n;
        bool check;
        do
        {
            n = InputNumber();
            if (n < start || n > end)
            {
                check = false;
                Console.WriteLine($"Input integer from {start} to {end}");
            }
            else
            {
                check = true;
            }
        }
        while (!check);

        return n;
    }

    public static int InputMoreThanZero()
    {
        int n;
        bool check;
        do
        {
            n = InputNumber();
            if (n < 0)
            {
                check = false;
                Console.WriteLine("Input 0 or more.");
            }
            else
            {
                check = true;
            }
        }
        while (!check);

        return n;
    }



    public static void Main(string[] args)
    {
        var services = CompositionRoot.Services;
        var pendingCommandService = services.GetRequiredService<PendingCommandService>();
        var bankAccountRepo = services.GetRequiredService<BankAccountRepository>();
        var bankAccountIDService = services.GetRequiredService<BankAccountIDService>();
        var bankAccountFactory = services.GetRequiredService<BankAccountFactory>();

        var categoryRepo = services.GetRequiredService<CategoryRepository>();
        var categoryIDService = services.GetRequiredService<CategoryIDService>();
        var categoryFactory = services.GetRequiredService<CategoryFactory>();

        var operationRepo = services.GetRequiredService<OperationRepository>();
        var operationIDService = services.GetRequiredService<OperationIDService>();
        var operationFactory = services.GetRequiredService<OperationFactory>();

        var bankAccountInventoryService = services.GetRequiredService<BankAccountInventoryService>();

        var categoryInventoryService = services.GetRequiredService<CategoryInventoryService>();

        var operationInventoryService = services.GetRequiredService<OperationInventoryService>();

        bool exit = false;
        do
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Add new bank account.");
            Console.WriteLine("2 - Delete bank account.");
            Console.WriteLine("3 - Edit bank account.");
            Console.WriteLine("4 - Get bank account.");
            Console.WriteLine("5 - Add new category.");
            Console.WriteLine("6 - Delete category.");
            Console.WriteLine("7 - Edit category.");
            Console.WriteLine("8 - Get category.");
            Console.WriteLine("9 - Add new operation.");
            Console.WriteLine("10 - Delete operation.");
            Console.WriteLine("11 - Edit operation.");
            Console.WriteLine("12 - Get operation.");
            Console.WriteLine("13 - Show information about all of bank accounts.");
            Console.WriteLine("14 - Show information about all of categories.");
            Console.WriteLine("15 - Show information about all of operations.");
            Console.WriteLine("16 - Get report about with all operations, categories, bank accounts.");
            Console.WriteLine("0 - exit.");
            int choice = InputNumber();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Input name of your bank account: ");
                    string name = InputString();//Console.ReadLine();
                    Console.WriteLine("Input start sum of your bank account balance: ");
                    int balance = InputMoreThanZero();
                    bankAccountInventoryService.AddBankAccountPending(name, balance);
                    CompositionRoot.PendingCommandService.SaveChanges();
                    break;
                case 2:
                    Console.WriteLine("Input ID of bank account you want to delete: ");
                    int id = InputNumber();
                    bankAccountInventoryService.RemoveBankAccountPending(id);
                    CompositionRoot.PendingCommandService.SaveChanges();
                    break;
                case 3:
                    Console.WriteLine("Input ID of bank account you want to edit: ");
                    int id_edit = InputNumber();
                    bankAccountInventoryService.UpdateBankAccountPending(id_edit);
                    CompositionRoot.PendingCommandService.SaveChanges();
                    break;
                case 4:
                    Console.WriteLine("Input ID of bank account that you want to know about: ");
                    int id_bank_account_get = InputNumber();
                    bankAccountInventoryService.GetBankAccountPending(id_bank_account_get);
                    CompositionRoot.PendingCommandService.SaveChanges();
                    break;
                case 5:
                    Console.WriteLine("Input type of category (income/consumption): ");
                    Console.WriteLine("1 - income.");
                    Console.WriteLine("2 - consumption.");
                    bool type = false;
                    bool valid_type_category_input = false;
                    do
                    {
                        int choice_type_category = InputNumber();
                        switch (choice_type_category)
                        {
                            case 1:
                                type = true;
                                valid_type_category_input = true;
                                break;
                            case 2:
                                type = false;
                                valid_type_category_input = true;
                                break;
                            default:
                                Console.WriteLine("Invalid input. Enter 1 or 2.");
                                break;
                        }
                    } while (!valid_type_category_input);
                    Console.WriteLine("Input name of category: ");
                    string name_category = Console.ReadLine();
                    categoryInventoryService.AddCategoryPending(type, name_category);
                    pendingCommandService.SaveChanges();
                    break;
                case 6:
                    Console.WriteLine("Input ID of category you want to delete: ");
                    int id_category_delete = InputNumber();
                    categoryInventoryService.RemoveCategoryPending(id_category_delete);
                    pendingCommandService.SaveChanges();
                    break;
                case 7:
                    Console.WriteLine("Input ID of category you want to edit: ");
                    int id_category_update = InputNumber();
                    categoryInventoryService.UpdateCategoryPending(id_category_update);
                    pendingCommandService.SaveChanges();
                    break;
                case 8:
                    Console.WriteLine("Input ID of category that you want to know about: ");
                    int id_category_get = InputNumber();
                    categoryInventoryService.GetCategoryPending(id_category_get);
                    pendingCommandService.SaveChanges();
                    break;
                case 9:
                    List<BankAccount> bankAccounts = bankAccountRepo.GetAll().ToList();
                    List<Category> categories = categoryRepo.GetAll().ToList();
                    BankAccount bankAccount = null;
                    if (bankAccounts.Count == 0 || categories.Count == 0)
                    {
                        Console.WriteLine("No bank accounts or categories yet.");
                        break;
                    }
                    Console.WriteLine("Input type of operation (income/consumption): ");
                    Console.WriteLine("1 - income.");
                    Console.WriteLine("2 - consumption.");
                    bool type_operation = false;
                    bool valid_type_operation_input = false;
                    do
                    {
                        int choice_type_category = InputNumber();
                        switch (choice_type_category)
                        {
                            case 1:
                                type_operation = true;
                                valid_type_operation_input = true;
                                break;
                            case 2:
                                type_operation = false;
                                valid_type_operation_input = true;
                                break;
                            default:
                                Console.WriteLine("Invalid input. Enter 1 or 2.");
                                break;
                        }
                    } while (!valid_type_operation_input);
                    Console.WriteLine("Here are all of available bank accounts: ");
                    for (int i = 0; i < bankAccounts.Count(); ++i)
                    {
                        Console.WriteLine((i + 1) + " - " + bankAccounts[i].BankAccountParams.Name);
                    }
                    Console.WriteLine("Choose ID of bank account: ");
                    int bank_account_id_for_operation_input = InputNumber(1, bankAccounts.Count());
                    bankAccount = bankAccounts[bank_account_id_for_operation_input - 1];
                    Console.WriteLine("Input amount of sum for operation: ");
                    int amount_operation = InputMoreThanZero();
                    Console.WriteLine("Input description: ");
                    string description = Console.ReadLine();

                    Category category = null;
                    Console.WriteLine("Here are all of available categories: ");
                    for (int i = 0; i < categories.Count(); ++i)
                    {
                        Console.WriteLine((i + 1) + " - " + categories[i].Params.Name);
                    }
                    Console.WriteLine("Choose ID of category: ");
                    int category_id_for_operation_input = InputNumber(1, categories.Count());
                    category = categories[category_id_for_operation_input - 1];
                    operationInventoryService.AddOperationPending(type_operation, bankAccount, amount_operation, category, description);
                    pendingCommandService.SaveChanges();
                    break;
                case 10:
                    Console.WriteLine("Input ID of operation you want to delete: ");
                    int id_operation_delete = InputNumber();
                    operationInventoryService.RemoveOperationPending(id_operation_delete);
                    pendingCommandService.SaveChanges();
                    break;
                case 11:
                    Console.WriteLine("Input ID of operation you want to edit: ");
                    int id_operation_update = InputNumber();
                    operationInventoryService.UpdateOperationPending(id_operation_update);
                    pendingCommandService.SaveChanges();
                    break;
                case 12:
                    Console.WriteLine("Input ID of operation that you want to know about: ");
                    int id_operation_get = InputNumber();
                    operationInventoryService.GetOperationPending(id_operation_get);
                    pendingCommandService.SaveChanges();
                    break;
                case 13:
                    bankAccountInventoryService.ShowAccounts();
                    break;
                case 14:
                    categoryInventoryService.ShowCategoties();
                    break;
                case 15:
                    operationInventoryService.ShowOperations();
                    break;
                case 16:
                    CompositionRoot.ReportsService.ExportReport(Console.Out);
                    break;
                case 0:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("There is no command like this");
                    break;
            }

        } while (!exit);

    }
}