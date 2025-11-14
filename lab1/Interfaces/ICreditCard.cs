namespace PaymentsSystem.Interfaces;

public interface ICreditCard
{
    string CardNumber { get; }
    decimal CurrentDebt { get; }
    decimal CreditLimit { get; }
    bool IsBlocked { get; }
    
    void Pay(decimal amount);
    void Block();
}
