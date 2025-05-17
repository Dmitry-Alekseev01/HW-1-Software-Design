# БДЗ-1. Модуль банковского учёта 

## Выполнил Алексеев Дмитрий Денисович из группы БПИ-236

### Как пользоваться?

Я сделал менюшку с командами для пользователя.  Что вы хотите сделать в данный момент, то и выбираете на менюшке.

```csharp
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
```
Вот так это выглядит, а после этого кода идёт уже switch, в котором и вызывваются нужные методы. Также я сделал несколько функций для проверки правильности ввода. Например:

```csharp
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
```

Это чтобы проверять, действительно ли пользователь ввёл число.

### Теперь о принципах SOLID, использованных мною.

#### 1. Dependency injection.

Для реализации этого принципа я использовал DI-контейнер, доступный с помощью библиотеки Microsoft.Extensions.DependencyInjection.

```csharp
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
```

Он находится в отедльном классе CompositionRoot.

Также у меня вообще нет наследования классов, то есть все зависимости строятся на итерфейсах или абстрактных классах (абстракциях).

#### 2. Interface segregation.

Принцип заключается в том, что каждый интерфейс выполняет только то, что должен класс, который его будет реализовывать, и ничего больше.

Приведу в пример код пары своих интерфейсов для наглядности:

```csharp
public interface ICategoryFactory<TParams>
{
    public Category CreateCategory(TParams categoryParams, int ID);
}
```
Это интерфейс для фабричного метода, который создаёт категории.

```csharp
public interface ICategoryRepository
{
    void Add(Category category);

    void Remove(Category category);

    IEnumerable<Category> GetAll();

}
```

Это интерфейс для репозитория категорий. 

Как видно, в обоих в пределах пяти методов, каждый из которых нужен в конкреином классе, который их реализует.

#### 3. Single responsibility.

В моём проекте каждый класс выполняет только ту задачу, которая ему предначертана. Ни больше, ни меньше. Например: 

```csharp
public class CategoryFactory : ICategoryFactory<CategoryParams>
{
    public Category CreateCategory(CategoryParams categoryParams, int ID)
    {
        Category category = new Category(ID, categoryParams);

        return category;
    }
}
```

Это класс, который создаёт категории. Как видно, он занимается только тем, что создаёт категории, не делая ровным счётом ничего сверх того. 

Или ещё пример: 

```csharp
public class CategoryRepository : ICategoryRepository
{
    private readonly List<Category> categories = new();

    public List<Category> Categories { get { return categories; } }

    public void Add(Category category)
    {
        categories.Add(category);
    }

    public IEnumerable<Category> GetAll()
    {
        return categories.AsReadOnly();
    }

    public void Remove(Category category)
    {
        categories.Remove(category);
    }
}
```

Это класс, который хранит категории (репозиторий). Он точно так же выполняет лишь то, что нужно. Всё только то, что нужно для хранилища: добавить, удалить, получить всё.

#### 4. Принцип открытости/закрытости.

Я отказался от наследования, как я уже сказал, сделав только интерфейсы, поэтому, если я захочу добавить что-то новое (например, класс пользователя), то мне не придётся ничего менять в старых. Я смогу его просто реализовать и добавить ему в качестве свойства ссылку на банковский аккаунт.

#### 5. Принцип подтсановки Барбары Лисков.

У меня нет наследования, поэтому нет и подтипов. Но думаю, что гипотетически, если я захочу сделать какой-то класс, похожий на, к примеру, Operation, то я смогу его подставить в фабрику операций и создавать его там тоже.


#### High cohesion и Low Coupling.

На лекции было сказано, что эти принципы тесно связаны с принципами SOLID, то есть High Cohesion следует из Single Responsobility, а Low Coupling - из Single Responsobility и Interface segregation, поэтому могу сказать, что раз у меня реализованы соответствующие принципы SOLID, то у меня реализованы и эти принципы GRASP.

### Паттерны.

#### 1. Фабричный метод

Ранее я уже привёл в пример код фабричного метода для категорий, а сейчас приведу для операций: 

```csharp
public class OperationFactory : IOperationFactory<OperationParams>
{
    public Operation CreateOperation(OperationParams param, int ID)
    {
        Operation operation = new Operation(ID, param);
        return operation;
    }
}
```

Я использую этот паттерн, чтобы удобно было создавать объекты основных классов: банковский счёт, операции и категории. Они создаются в одном месте, как видно, кода совсем мало, плюс это очень удобно, что мы всех их создаём с помощью одного класса в одном месте.

#### 2. Репозиторий

Пример:

```csharp
public class OperationRepository : IOperationRepository
{
    private readonly List<Operation> operations = new();

    public List<Operation> Operations { get { return operations; } }

    public void Add(Operation operation)
    {
        operations.Add(operation);
    }

    public IEnumerable<Operation> GetAll()
    {
        return operations.AsReadOnly();
    }

    public void Remove(Operation operation)
    {
        operations.Remove(operation);
    }

}
```

Этот паттерн я использую, чтобы создать хранилище для наших основных классов. Это очень удобно, здесь есть список наших объектов, мы можем его полностью получить, быстро в него что-то добавить или удалить.

#### 3. Фасад

```csharp
public class CategoryInventoryService(
    PendingCommandService pendingCommandService,
    ICategoryRepository categoryRepository,
    CategoryIDService categoryIDService,
    CategoryFactory categoryFactory)
{
    public void AddCategoryPending(bool type, string name)
    {
        var command = new AddCategoryCommand(categoryRepository, categoryIDService, categoryFactory, type, name);
        pendingCommandService.AddCommand(command);
    }

    public void RemoveCategoryPending(int ID)
    {
        var command = new DeleteCategoryCommand(categoryRepository, ID);
        pendingCommandService.AddCommand(command);
    }

    public void GetCategoryPending(int ID)
    {
        var command = new GetCategoryCommand(categoryRepository, ID);
        pendingCommandService.AddCommand(command);
    }

    public void UpdateCategoryPending(int ID)
    {
        var command = new UpdateCategoryCommand(categoryRepository, ID);
        pendingCommandService.AddCommand(command);
    }

    public void ShowCategoties()
    {
        var categories = categoryRepository.GetAll().ToList();
        for (int i = 0; i < categories.Count; i++)
        {
            Console.WriteLine(categories[i].ToString());
        }
    }
}
```

Точно так же сделал его для всех основных классов со всем основным функционалом, который озвучили в задании: создать новый и добавить в репозиторий, удалить, получить информацию о конкретном и редактировать. Этот паттерн позволяет без лишних движений выполнить все озвученные действия благодаря наличию одного класса, который в себе содержит функционал для всех нужных действий. ID, кстати говоря, считается сам в классе CategoryIDService. 

#### 4. Builder

Этот паттерн я использую для создания отчёта:

```csharp
public class ReportBuilder
{
    private readonly StringBuilder _content = new();

    public ReportBuilder AddBankAccounts(IEnumerable<BankAccount> bankAccounts)
    {
        _content.AppendLine("Bank accounts:");

        foreach (var bankAccount in bankAccounts)
        {
            _content.AppendLine($"Bank account: Number: {bankAccount.ID}, Name: {bankAccount.BankAccountParams.Name}, Balance: {bankAccount.BankAccountParams.Balance}");
        }

        _content.AppendLine();
        return this;
    }

    public ReportBuilder AddCategories(IEnumerable<Category> categories)
    {
        _content.AppendLine("Categories:");

        foreach (var category in categories)
        {
            _content.AppendLine($"Category: ID: {category.ID}, Name of category: {category.Params.Name}");
            _content.AppendLine();
        }

        return this;
    }

    public ReportBuilder AddOperations(IEnumerable<Operation> operations)
    {
        _content.AppendLine("Operations: ");

        foreach (var operation in operations)
        {
            _content.AppendLine($"Operation: ID: {operation.ID}, ID of bank account: {operation.Params.BankAccountID}, Sum: {operation.Params.Amount}, Date of operation: {operation.Params.Date}, Description: {operation.Params.Description}, ID of category: {operation.Params.CategoryID}");
            _content.AppendLine();
        }

        return this;
    }

    public void ClearReport()
    {
        _content.Clear();
    }

    public Report Build()
    {
        return new Report($"Report for {DateTime.Now:yyyy-MM-dd}", _content.ToString());
    }

}
```

Сделаю замечание: это из доп функционала, написано, что его можно чуть-чуть изменять, поэтому я сделал экспорт данных в только в один формат маркдаун. Паттерн используется чисто в этом месте, каждый метод добавляет информацию о тех или иных объектах, что достаточно удобно, потому что мы разбили создание отчёта на несколько методов, сделав потом ещё один, который их всех объединяет.

#### 5. Команда

У меня все основные команды (кроме вывода информации обо всей коллекции объектов) из меню реализованы с помощью отдельных классов, а также для них я сделал отдельный сервис. Пример одной команды:

```csharp
public class AddBankAccountCommand(
    IBankAccountRepository bankAccountRepository,
    BankAccountIDService bankAccountIDService,
    BankAccountFactory bankAccountFactory,
    string name, 
    int balance
    ) : IAccountingSessionCommand
{
    public void Apply()
    {
        int bankAccountID = bankAccountIDService.GetNextNumber();
        BankAccountParams bankAccountParams = new BankAccountParams(name, balance);
        BankAccount bankAccount = bankAccountFactory.CreateBankAccount(bankAccountParams, bankAccountID);
        bankAccountRepository.Add(bankAccount);
    }

    public override string ToString() => $"Bank account added. Name: {name}. Balance: {balance}.";
}
```

Это удобно, потому что для каждой команды своя реализация, и в каждом классе мы можем контролировать, чтобы всё вводилось корректно и всё исполнялось.