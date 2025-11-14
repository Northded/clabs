using PaymentsSystem.Interfaces;

namespace PaymentsSystem.Classes;

public class BankAccount : IAccount
{
    public string Number { get; }
    public decimal Balance { get; private set; }
    public bool IsClosed { get; private set; }
    
    public BankAccount(string number, decimal initialBalance)
    {
        Number = number;
        Balance = initialBalance;
        IsClosed = false;
    }
    
    public void Deposit(decimal amount)
    {
        if (IsClosed)
            throw new InvalidOperationException("Account is closed");
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");
        
        Balance += amount;
    }
    
    public void Withdraw(decimal amount)
    {
        if (IsClosed)
            throw new InvalidOperationException("Account is closed");
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");
        if (amount > Balance)
            throw new InvalidOperationException("Insufficient funds");
        
        Balance -= amount;
    }
    
    public void Close()
    {
        if (Balance != 0)
            throw new InvalidOperationException("Cannot close account with non-zero balance");
        
        IsClosed = true;
    }
}
