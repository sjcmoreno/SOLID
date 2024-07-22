﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemo.Accounts
{
    internal interface ICurrencyConverter
    {
        Currency Currency { get; }
        decimal ConvertToCurrency(decimal amount);
    }
}
