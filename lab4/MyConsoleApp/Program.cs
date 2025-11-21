using System;
using StructuralPatternsLab.AdapterPattern;
using StructuralPatternsLab.FacadePattern;

namespace StructuralPatternsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Демонстрация паттерна Адаптер (объекты) ===\n");
            DemonstrateAdapter();

            Console.WriteLine("\n\n=== Демонстрация паттерна Фасад ===\n");
            DemonstrateFacade();

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void DemonstrateAdapter()
        {
            GasCylinder hydrogen = new GasCylinder(0.05, 0.5, 0.002016);
            IGasCylinderAdapter adapter = new GasCylinderAdapter(hydrogen);

            Console.WriteLine("Начальные данные:");
            Console.WriteLine(adapter.GetData());

            Console.WriteLine("\n--- Изменение давления ---");
            double dp = adapter.CalculateDp(273, 50);
            Console.WriteLine($"Изменение давления при T0=273K и dT=50K: {dp:F2} Па");

            Console.WriteLine("\n--- Изменение массы газа ---");
            adapter.ModifMass(0.1);

            Console.WriteLine("\nДанные после изменения:");
            Console.WriteLine(adapter.GetData());
        }

        static void DemonstrateFacade()
        {
            CalorieCalculatorFacade facade = new CalorieCalculatorFacade();

            Console.WriteLine("Пример 1: Астеник");
            Console.WriteLine(facade.GetCalorieReport("астеник", 180, 70, 25, Gender.Male, ActivityLevel.Medium));

            Console.WriteLine("\nПример 2: Нормостеник");
            Console.WriteLine(facade.GetCalorieReport("нормостеник", 165, 60, 30, Gender.Female, ActivityLevel.Low));

            Console.WriteLine("\nПример 3: Гиперстеник");
            Console.WriteLine(facade.GetCalorieReport("гиперстеник", 175, 85, 40, Gender.Male, ActivityLevel.High));
        }
    }
}
