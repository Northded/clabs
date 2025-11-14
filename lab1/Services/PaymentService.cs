using PaymentsSystem.Interfaces;
using PaymentsSystem.Classes;

namespace PaymentsSystem.Services;

public class PaymentService
{
    public void ProcessOrderPayment(Order order, ICreditCard creditCard)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));
        if (creditCard == null)
            throw new ArgumentNullException(nameof(creditCard));
        if (order.IsPaid)
            throw new InvalidOperationException("Order is already paid");
        
        creditCard.Pay(order.Amount);
        
        order.MarkAsPaid();
    }
    
    public void ProcessTransfer(IAccount fromAccount, IAccount toAccount, decimal amount)
    {
        if (fromAccount == null)
            throw new ArgumentNullException(nameof(fromAccount));
        if (toAccount == null)
            throw new ArgumentNullException(nameof(toAccount));
        if (fromAccount == toAccount)
            throw new InvalidOperationException("Cannot transfer to the same account");
        
        fromAccount.Withdraw(amount);
        
        toAccount.Deposit(amount);
    }
}
