using System;

namespace AtmStatePattern.States
{
    public class WaitingState : IAtmState
    {
        public void EnterPin(AtmContext context, string pin)
        {
            if (!context.IsConnected)
            {
                Console.WriteLine("Нет связи с банком. Банкомат заблокирован.");
                context.State = new BlockedState();
                return;
            }
            if (pin == "1234")
            {
                Console.WriteLine("PIN принят. Добро пожаловать!");
                context.IsAuthenticated = true;
                context.State = new AuthenticatedState();
            }
            else
            {
                Console.WriteLine("Неверный PIN.");
            }
        }

        public void Withdraw(AtmContext context, decimal amount) =>
            Console.WriteLine("Сначала введите PIN.");

        public void Finish(AtmContext context) =>
            Console.WriteLine("Сеанс не активен.");

        public void LoadCash(AtmContext context, decimal amount)
        {
            context.Cash += amount;
            Console.WriteLine($"В банкомат загружено {amount} руб. Текущий остаток: {context.Cash}");
        }
    }
}
