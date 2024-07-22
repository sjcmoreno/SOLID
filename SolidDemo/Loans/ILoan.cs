using SolidDemo.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemo.Loans
{
    internal interface ILoan
    {
        public decimal Amount { get; }
        
        public double InterestRate { get; }

        public int Duration { get; }

        public string Type { get; }

        decimal CalculateTotalPayments();
    }
}
