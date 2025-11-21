using System;

namespace AtmStatePattern.States
{
    public class BlockedState : IAtmState
    {
        public void EnterPin(AtmContext context, string pin) =>
            Console.WriteLine("Банкомат заблокирован. Операции невозможны.");

        public void Withdraw(AtmContext context, decimal amount) =>
            Console.WriteLine("Банкомат заблокирован. Операции невозможны.");

        public void Finish(AtmContext context) =>
            Console.WriteLine("Банкомат заблокирован.");

        public void LoadCash(AtmContext context, decimal amount)
        {
            context.Cash += amount;
            Console.WriteLine($"Банкомат разблокирован. Загружено {amount} руб. Текущий остаток: {context.Cash}");
            context.State = new WaitingState();
        }
    }
}
