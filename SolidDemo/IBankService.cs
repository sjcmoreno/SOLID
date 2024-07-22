using SolidDemo.Accounts;

namespace SolidDemo;

internal interface IBankService
{
    void CalculateTotalLoanPayments(Customer customer);
    void Withdraw(Customer customer, int accountId, decimal amount, Currency? currency = null);
}