namespace AtmStatePattern.States
{
    public interface IAtmState
    {
        void EnterPin(AtmContext context, string pin);
        void Withdraw(AtmContext context, decimal amount);
        void Finish(AtmContext context);
        void LoadCash(AtmContext context, decimal amount);
    }
}
