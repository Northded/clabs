using System;

namespace AtmStatePattern.States
{
    public class OperatingState : IAtmState
    {
        public void EnterPin(AtmContext context, string pin) =>
            Console.WriteLine("Операция невозможна: сеанс уже активен.");

        public void Withdraw(AtmContext context, decimal amount)
        {
            if (amount > context.Cash)
            {
                Console.WriteLine("Недостаточно средств. Банкомат блокируется.");
                context.State = new BlockedState();
                return;
            }
            context.Cash -= amount;
            Console.WriteLine($"Выдано {amount} руб. Остаток: {context.Cash} руб.");

            if (context.Cash == 0)
            {
                Console.WriteLine("В банкомате закончились деньги. Банкомат блокируется.");
                context.State = new BlockedState();
            }
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
