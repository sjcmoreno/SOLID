using SolidDemo.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemo.Validations
{
    internal class DollarAccountValidation : IAccountValidation
    {
        public AccountType AccountType => AccountType.Dollar;

        public bool IsValid(IAccount account, decimal amount)
        {
            return amount > 0 && amount <= account.Balance;
        }
    }
}
