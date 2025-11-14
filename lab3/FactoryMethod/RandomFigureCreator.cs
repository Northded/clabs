using System;

namespace DesignPatterns.FactoryMethod
{
    /// <summary>
    /// ПАТТЕРН FACTORY METHOD - Конкретный создатель 1
    /// Переопределяет фабричный метод для создания случайных фигур
    /// </summary>
    public class RandomFigureCreator : FigureCreator
    {
        private Random random = new Random();

        public override IFigure CreateFigure()
        {
            int choice = random.Next(0, 5);
            return choice switch
            {
                0 => new IFigureShape(),
                1 => new OFigureShape(),
                2 => new TFigureShape(),
                3 => new LFigureShape(),
                4 => new SuperFigureShape(),
                _ => new IFigureShape()
            };
        }
    }
}
