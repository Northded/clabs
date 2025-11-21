using System;

namespace AtmStatePattern.States
{
    public class AuthenticatedState : IAtmState
    {
        public void EnterPin(AtmContext context, string pin) =>
            Console.WriteLine("Вы уже аутентифицированы.");

        public void Withdraw(AtmContext context, decimal amount)
        {
            if (!context.IsConnected)
            {
                Console.WriteLine("Нет связи с банком. Банкомат заблокирован.");
                context.State = new BlockedState();
                return;
            }
            if (amount > context.Cash)
            {
                Console.WriteLine("Недостаточно средств в банкомате. Банкомат блокируется.");
                context.State = new BlockedState();
                return;
            }
            context.Cash -= amount;
            Console.WriteLine($"Выдано {amount} руб. Остаток: {context.Cash} руб.");

            context.State = context.Cash == 0 ? (IAtmState)new BlockedState() : new OperatingState();
        }

        public void Finish(AtmContext context)
        {
            context.IsAuthenticated = false;
            context.State = new WaitingState();
            Console.WriteLine("Сеанс завершён.");
        }

        public void LoadCash(AtmContext context, decimal amount)
        {
            context.Cash += amount;
            Console.WriteLine($"В банкомат загружено {amount} руб. Текущий остаток: {context.Cash}");
        }
    }
}
