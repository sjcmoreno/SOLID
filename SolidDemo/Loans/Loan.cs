using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemo.Loans
{
    internal abstract class Loan(decimal amount, double interestRate, int duration, string type) : ILoan
    {
        public decimal Amount { get; } = amount;
        public double InterestRate { get; } = interestRate;
        public int Duration { get; } = duration;
        public string Type { get; } = type;

        public decimal CalculateTotalPayments()
        {
            return Amount * (decimal)Math.Pow(1 + InterestRate, Duration);
        }
    }
}
