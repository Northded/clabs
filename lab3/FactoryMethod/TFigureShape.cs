using System;

namespace DesignPatterns.FactoryMethod
{
    public class TFigureShape : IFigure
    {
        public string GetName() => "T";
        public int GetCellsCount() => 4;
        
        public void Display()
        {
            Console.WriteLine("███");
            Console.WriteLine(" █ ");
        }
    }
}
