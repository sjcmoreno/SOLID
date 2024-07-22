using Microsoft.Extensions.DependencyInjection;
using SolidDemo.Accounts;
using SolidDemo.Loans;
using SolidDemo.Validations;

namespace SolidDemo;

internal class Program
{
    static void Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddScoped<ILoggingService, LoggingService>();
        serviceCollection.AddScoped<IBankService, BankService>();  
        serviceCollection.AddScoped<IAccountValidation, SavingsAccountValidation>();
        serviceCollection.AddScoped<IAccountValidation, CurrentAccountValidation>();
        serviceCollection.AddScoped<IAccountValidation, TimeDepositValidation>();
        serviceCollection.AddScoped<IAccountValidation, DollarAccountValidation>();
        serviceCollection.AddScoped<ICurrencyConverter, PesoCurrencyConverter>();
        serviceCollection.AddScoped<ICurrencyConverter, DollarCurrencyConverter>();
        serviceCollection.AddScoped<ICurrencyConversionService, CurrencyConversionService>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var bankService = serviceProvider.GetRequiredService<IBankService>();

        var savingsAccount = new SavingsAccount(1001, 500.00m);
        var currentAccount = new CurrentAccount(1002, 500.00m, 100m);
        var timeDepositAccount = new TimeDepositAccount(1003, 500m, DateTime.Today.Subtract(TimeSpan.FromDays(29)), 30);
        var dollarAccount = new DollarAccount(1004, 500m);

        var housingLoan = new HousingLoan(100000m, 15);
        var personalLoan = new PersonalLoan(1000000m, 1);
        var carLoan = new CarLoan(2000000m, 5);

        var customer = new Customer(1, "Juan Dela Cruz", new List<IAccount>
        {
            savingsAccount,
            currentAccount,
            timeDepositAccount,
            dollarAccount
        },
        new List<ILoan>
        {
            housingLoan,
            personalLoan,
            carLoan
        });


        bankService.Withdraw(customer, 1001, 100.00m);
        bankService.Withdraw(customer, 1002, 600.00m);
        bankService.Withdraw(customer, 1003, 300m);
        bankService.Withdraw(customer, 1004, 1, Currency.Peso);
        bankService.CalculateTotalLoanPayments(customer);

        Console.ReadLine();
    }
}
