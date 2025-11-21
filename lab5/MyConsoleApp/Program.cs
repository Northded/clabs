using System;

namespace AtmStatePattern
{
    class Program
    {
        static void Main()
        {
            AtmContext atm = new AtmContext("ATM-01", 10000, 0.05);
            Console.WriteLine("=== Банкомат готов к работе ===");

            atm.EnterPin("0000"); // неверный PIN
            atm.EnterPin("1234");
            atm.Withdraw(3000);
            atm.Withdraw(8000); // недостаток средств — блокировка
            atm.LoadCash(15000); // загрузка денег, разблокировка
            atm.EnterPin("1234");
            atm.Withdraw(5000);
            atm.Finish();

            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadKey();
        }
    }
}
