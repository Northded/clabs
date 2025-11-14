using PaymentsSystem.Interfaces;

namespace PaymentsSystem.Services;

public class AccountManagementService
{
    public void BlockCreditCard(ICreditCard creditCard)
    {
        if (creditCard == null)
            throw new ArgumentNullException(nameof(creditCard));
        if (creditCard.IsBlocked)
            throw new InvalidOperationException("Card is already blocked");
        
        creditCard.Block();
    }

    public void CloseAccount(IAccount account)
    {
        if (account == null)
            throw new ArgumentNullException(nameof(account));
        if (account.IsClosed)
            throw new InvalidOperationException("Account is already closed");
        
        account.Close();
    }
}
