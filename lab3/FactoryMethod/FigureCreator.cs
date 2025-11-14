using System;

namespace DesignPatterns.FactoryMethod
{
    public abstract class FigureCreator
    {
        public abstract IFigure CreateFigure();
        public void SpawnFigure()
        {
            IFigure figure = CreateFigure();
            
            Console.WriteLine($"\n🎮 Появилась фигура: {figure.GetName()} ({figure.GetCellsCount()} клеток)");
            figure.Display();
        }
    }
}
