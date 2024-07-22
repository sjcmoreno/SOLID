using SolidDemo.Loans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemo.Accounts
{
    internal class DollarAccount(int accountId, decimal balance) : Account(accountId, balance), IAccount
    {
        private const decimal _depositFee = 0.98m;

        public AccountType AccountType => AccountType.Dollar;

        public override void Deposit(decimal amount)
        {
            var amountAfterFee = amount * _depositFee;

            Balance -= amountAfterFee;
        }
    }
}
