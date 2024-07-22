using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemo.Accounts
{
    internal class PesoCurrencyConverter : ICurrencyConverter
    {
        private const decimal _conversionRate = 55;

        public Currency Currency => Currency.Peso;

        public decimal ConvertToCurrency(decimal amount)
        {
            return amount * _conversionRate;
        }
    }
}
