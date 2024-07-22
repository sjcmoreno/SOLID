using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemo.Accounts
{
    internal class DollarCurrencyConverter : ICurrencyConverter
    {
        public Currency Currency => Currency.Dollar;

        public decimal ConvertToCurrency(decimal amount)
        {
            return amount;
        }
    }
}
