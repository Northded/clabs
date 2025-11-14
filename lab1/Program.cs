using PaymentsSystem.Classes;
using PaymentsSystem.Interfaces;
using PaymentsSystem.Services;

namespace PaymentsSystem;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Создание счетов
        IAccount account1 = new BankAccount("ACC001", 1000m);
        IAccount account2 = new BankAccount("ACC002", 500m);
        
        // Создание кредитной карты
        ICreditCard creditCard = new CreditCard("CARD001", 2000m);
        
        // Создание клиента
        Client client = new Client("John Doe", account1, creditCard);
        
        // Создание сервисов
        var paymentService = new PaymentService();
        var accountService = new AccountManagementService();
        var administrator = new Administrator();
        
        Console.WriteLine($"Клиент: {client.Name}");
        Console.WriteLine($"Счет: {account1.Number}, Баланс: {account1.Balance:C}");
        Console.WriteLine($"Кредитная карта: {creditCard.CardNumber}, Лимит: {creditCard.CreditLimit:C}\n");
        
        //Оплата заказа
        Console.WriteLine("ТЕСТ 1: ОПЛАТА ЗАКАЗА");
        try
        {
            var order1 = new Order("ORD001", 500m);
            Console.WriteLine($"Создан заказ: ID={order1.OrderId}, Сумма={order1.Amount:C}");
            
            paymentService.ProcessOrderPayment(order1, creditCard);
            Console.WriteLine($"Заказ {order1.OrderId} успешно оплачен");
            Console.WriteLine($"Текущий долг по карте: {creditCard.CurrentDebt:C}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
        
        //Оплата заказа 2
        Console.WriteLine("ТЕСТ 2: ОПЛАТА ВТОРОГО ЗАКАЗА");
        try
        {
            var order2 = new Order("ORD002", 800m);
            Console.WriteLine($"Создан заказ: ID={order2.OrderId}, Сумма={order2.Amount:C}");
            
            paymentService.ProcessOrderPayment(order2, creditCard);
            Console.WriteLine($"Заказ {order2.OrderId} успешно оплачен");
            Console.WriteLine($"Текущий долг по карте: {creditCard.CurrentDebt:C}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
        
        //Попытка превышения кредитного лимита
        Console.WriteLine("ТЕСТ 3: ПРЕВЫШЕНИЕ КРЕДИТНОГО ЛИМИТА");
        try
        {
            var order3 = new Order("ORD003", 800m);
            Console.WriteLine($"Попытка оплатить заказ: ID={order3.OrderId}, Сумма={order3.Amount:C}");
            
            paymentService.ProcessOrderPayment(order3, creditCard);
            Console.WriteLine($"Заказ оплачен");
            Console.WriteLine($"Текущий долг: {creditCard.CurrentDebt:C}\n");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.WriteLine($"Текущий долг: {creditCard.CurrentDebt:C}, Лимит: {creditCard.CreditLimit:C}\n");
        }
        
        //Проверка превышения лимита администратором
        Console.WriteLine("ТЕСТ 4: ПРОВЕРКА И БЛОКИРОВКА АДМИНИСТРАТОРОМ");
        bool exceeded = administrator.IsCreditLimitExceeded(creditCard);
        Console.WriteLine($"Долг превышает лимит: {exceeded}");
        
        if (exceeded)
        {
            administrator.BlockCardForExceededCredit(creditCard);
            Console.WriteLine($"Карта {creditCard.CardNumber} заблокирована администратором");
        }
        Console.WriteLine($"Карта заблокирована: {creditCard.IsBlocked}\n");
        
        //Попытка платежа заблокированной карте
        Console.WriteLine("ТЕСТ 5: ПЛАТЕЖ ЗАБЛОКИРОВАННОЙ КАРТЕ");
        try
        {
            var order4 = new Order("ORD004", 300m);
            paymentService.ProcessOrderPayment(order4, creditCard);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
        
        //Перевод между счетами 
        Console.WriteLine("ТЕСТ 6: ДЕНЕЖНЫЙ ПЕРЕВОД");
        try
        {
            decimal transferAmount = 200m;
            Console.WriteLine($"Перевод {transferAmount:C} со счета {account1.Number} на счет {account2.Number}");
            
            paymentService.ProcessTransfer(account1, account2, transferAmount);
            Console.WriteLine($"Перевод успешен");
            Console.WriteLine($"Баланс {account1.Number}: {account1.Balance:C}");
            Console.WriteLine($"Баланс {account2.Number}: {account2.Balance:C}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Ошибка: {ex.Message}\n");
        }
        
        //Блокировка карты клиентом
        Console.WriteLine("ТЕСТ 7: БЛОКИРОВКА КАРТЫ КЛИЕНТОМ");
        try
        {
            // Создаем новую разблокированную карту для этого теста
            ICreditCard newCard = new CreditCard("CARD002", 1500m);
            Console.WriteLine($"Создана новая карта: {newCard.CardNumber}");
            
            accountService.BlockCreditCard(newCard);
            Console.WriteLine($"Карта {newCard.CardNumber} успешно заблокирована клиентом");
            Console.WriteLine($"Карта заблокирована: {newCard.IsBlocked}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
        
        //ТЕСТ 8: Закрытие счета
        Console.WriteLine("ТЕСТ 8: ЗАКРЫТИЕ СЧЕТА");
        try
        {
            // Создаем новый счет с нулевым балансом
            IAccount tempAccount = new BankAccount("ACC003", 0m);
            Console.WriteLine($"Создан счет: {tempAccount.Number}, Баланс: {tempAccount.Balance:C}");
            
            accountService.CloseAccount(tempAccount);
            Console.WriteLine($"Счет {tempAccount.Number} успешно закрыт");
            Console.WriteLine($"Счет закрыт: {tempAccount.IsClosed}\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
    }
}
