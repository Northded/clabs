namespace PaymentsSystem.Interfaces;

public interface IAccount
{
    string Number { get; }
    decimal Balance { get; }
    bool IsClosed { get; }
    
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    void Close();
}
