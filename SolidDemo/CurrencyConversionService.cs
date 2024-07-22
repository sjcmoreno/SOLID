using SolidDemo.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemo
{
    internal class CurrencyConversionService : ICurrencyConversionService
    {
        private readonly IDictionary<Currency, ICurrencyConverter> _currencyConverters;

        public CurrencyConversionService(IEnumerable<ICurrencyConverter> currencyConverters)
        {
            _currencyConverters = currencyConverters.ToDictionary(x => x.Currency, x => x);
        }

        public decimal ConvertToCurrency(decimal amount, Currency currency)
        {
            var isTargetCurrencyExist = _currencyConverters.TryGetValue(currency, out var targetCurrency);

            if (!isTargetCurrencyExist)
                throw new ArgumentException("Unsupported currency");

            if (targetCurrency == null)
                throw new ArgumentException("Target currency is not valid");

            return targetCurrency.ConvertToCurrency(amount);
        }
    }
}
