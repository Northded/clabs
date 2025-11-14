using System;

namespace DesignPatterns.FactoryMethod
{
    /// <summary>
    /// ПАТТЕРН FACTORY METHOD - Абстрактный создатель
    /// Объявляет фабричный метод, который должен возвращать объект типа IFigure
    /// </summary>
    public abstract class FigureCreator
    {
        /// <summary>
        /// Фабричный метод - делегирует создание объектов подклассам
        /// </summary>
        public abstract IFigure CreateFigure();

        /// <summary>
        /// Операция, использующая фабричный метод
        /// </summary>
        public void SpawnFigure()
        {
            // Вызываем фабричный метод для создания объекта
            IFigure figure = CreateFigure();
            
            Console.WriteLine($"\n🎮 Появилась фигура: {figure.GetName()} ({figure.GetCellsCount()} клеток)");
            figure.Display();
        }
    }
}
