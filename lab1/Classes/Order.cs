namespace PaymentsSystem.Classes;

public class Order
{
    public string OrderId { get; }
    public decimal Amount { get; }
    public bool IsPaid { get; private set; }
    public DateTime CreatedAt { get; }
    
    public Order(string orderId, decimal amount)
    {
        if (string.IsNullOrWhiteSpace(orderId))
            throw new ArgumentException("Order ID cannot be empty");
        if (amount <= 0)
            throw new ArgumentException("Amount must be positive");
        
        OrderId = orderId;
        Amount = amount;
        IsPaid = false;
        CreatedAt = DateTime.Now;
    }
    
    public void MarkAsPaid()
    {
        if (IsPaid)
            throw new InvalidOperationException("Order is already paid");
        
        IsPaid = true;
    }
}
