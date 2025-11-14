using PaymentsSystem.Interfaces;

namespace PaymentsSystem.Classes;

public class Client
{
    public string Name { get; }
    public IAccount Account { get; }
    public ICreditCard CreditCard { get; }
    
    public Client(string name, IAccount account, ICreditCard creditCard)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty");
        
        Name = name;
        Account = account;
        CreditCard = creditCard;
    }
}
