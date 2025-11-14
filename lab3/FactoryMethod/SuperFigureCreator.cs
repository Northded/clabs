namespace DesignPatterns.FactoryMethod
{
    public class SuperFigureCreator : FigureCreator
    {
        public override IFigure CreateFigure()
        {
            return new SuperFigureShape();
        }
    }
}
