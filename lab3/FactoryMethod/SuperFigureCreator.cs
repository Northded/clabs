namespace DesignPatterns.FactoryMethod
{
    /// <summary>
    /// ПАТТЕРН FACTORY METHOD - Конкретный создатель 2
    /// Переопределяет фабричный метод для создания только супер-фигур
    /// </summary>
    public class SuperFigureCreator : FigureCreator
    {
        public override IFigure CreateFigure()
        {
            return new SuperFigureShape();
        }
    }
}
