

using SolidDemo.Accounts;
using SolidDemo.Loans;
using SolidDemo.Validations;

namespace SolidDemo;

internal class BankService : IBankService
{
    private readonly ILoggingService _loggingService;
    private readonly ICurrencyConversionService _currencyConversionService;
    private readonly IDictionary<AccountType, IAccountValidation> _accountValidations;

    public BankService(ILoggingService loggingService, IEnumerable<IAccountValidation> accountValidations, ICurrencyConversionService currencyConversionService)
    {
        _loggingService = loggingService;
        _currencyConversionService = currencyConversionService;
        _accountValidations = accountValidations.ToDictionary(x => x.AccountType, y => y);
    }

    public void Withdraw(Customer customer, int accountId, decimal amount, Currency? currency = null)
    {
        var account = customer.GetAccount(accountId);

        if (!_accountValidations.TryGetValue(account.AccountType, out var accountValidation))
            throw new ArgumentException("Account type {account} is not Valid");

        if (!accountValidation.IsValid(account, amount))
        {
            if (account is ITimeDepositAccount timeDeposit)
                LogTimeDepositError(timeDeposit);
            else
                _loggingService.LogMessage("Withdrawal failed. Check the amount and balance.");

            return;
        }

        if (account is DollarAccount)
        {
            var convertedAmount = _currencyConversionService.ConvertToCurrency(amount, currency.GetValueOrDefault(Currency.Dollar));
            var convertedBalance = _currencyConversionService.ConvertToCurrency(account.Balance, currency.GetValueOrDefault(Currency.Dollar));

            account.Withdraw(amount);
            _loggingService.LogMessage($"Withdrawal of {convertedAmount} successful. New balance: {convertedBalance} {currency}");

            return;
        }

        account.Withdraw(amount);
        _loggingService.LogMessage($"Withdrawal of {amount} successful. New balance: {account.Balance}");
    }

    public void CalculateTotalLoanPayments(Customer customer)
    {
        foreach(var loan in customer.Loans)
        {
            var totalPayment = loan.CalculateTotalPayments();
            _loggingService.LogMessage($"Total payment amount for the {loan.Type} loan is {totalPayment}.");
        }
    }


    private void LogTimeDepositError(ITimeDepositAccount timeDeposit)
    {
        if (!timeDeposit.IsMatured())
            _loggingService.LogMessage("Time Deposit account did not reach maturity date");
    }
}
