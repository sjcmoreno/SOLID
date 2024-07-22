using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemo.Accounts
{
    internal interface IDollarAccount : IAccount
    {
        void Withdraw(decimal amount, Currency currency);
    }
}
