using SolidDemo.Accounts;

namespace SolidDemo
{
    internal interface ICurrencyConversionService
    {
        decimal ConvertToCurrency(decimal amount, Currency currency);
    }
}