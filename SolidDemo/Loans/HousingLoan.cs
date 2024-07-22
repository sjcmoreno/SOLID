using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidDemo.Loans
{
    internal class HousingLoan(decimal amount, int duration) : Loan(amount, 0.93, duration, "Housing")
    {
    }
}
