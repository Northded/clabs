using PaymentsSystem.Interfaces;

namespace PaymentsSystem.Classes;

public class Administrator
{
    public bool IsCreditLimitExceeded(ICreditCard creditCard)
    {
        if (creditCard == null)
            throw new ArgumentNullException(nameof(creditCard));
        
        return creditCard.CurrentDebt > creditCard.CreditLimit;
    }
    public void BlockCardForExceededCredit(ICreditCard creditCard)
    {
        if (creditCard == null)
            throw new ArgumentNullException(nameof(creditCard));
        
        if (IsCreditLimitExceeded(creditCard))
        {
            creditCard.Block();
        }
    }
}
