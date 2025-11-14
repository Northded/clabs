using PaymentsSystem.Interfaces;

namespace PaymentsSystem.Classes;

public class CreditCard : ICreditCard
{
    public string CardNumber { get; }
    public decimal CurrentDebt { get; private set; }
    public decimal CreditLimit { get; }
    public bool IsBlocked { get; private set; }
    
    public CreditCard(string cardNumber, decimal creditLimit)
    {
        CardNumber = cardNumber;
        CreditLimit = creditLimit;
        CurrentDebt = 0;
        IsBlocked = false;
    }
    
    public void Pay(decimal amount)
    {
        if (IsBlocked)
            throw new InvalidOperationException("Credit card is blocked");
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");
        if (CurrentDebt + amount > CreditLimit)
            throw new InvalidOperationException("Credit limit exceeded");
        
        CurrentDebt += amount;
    }
    
    public void Block()
    {
        IsBlocked = true;
    }
}
